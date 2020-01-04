@Override
	public void invoke() throws Exception {
		// --------------------------------------------------------------------
		// Initialize
		// --------------------------------------------------------------------
		if (LOG.isDebugEnabled()) {
			LOG.debug(formatLogString("Start registering input and output."));
		}

		// obtain task configuration (including stub parameters)
		Configuration taskConf = getTaskConfiguration();
		this.config = new TaskConfig(taskConf);

		// now get the operator class which drives the operation
		final Class<? extends Driver<S, OT>> driverClass = this.config.getDriver();
		this.driver = InstantiationUtil.instantiate(driverClass, Driver.class);

		String headName =  getEnvironment().getTaskInfo().getTaskName().split("->")[0].trim();
		this.metrics = getEnvironment().getMetricGroup()
			.getOrAddOperator(headName.startsWith("CHAIN") ? headName.substring(6) : headName);
		this.metrics.getIOMetricGroup().reuseInputMetricsForTask();
		if (config.getNumberOfChainedStubs() == 0) {
			this.metrics.getIOMetricGroup().reuseOutputMetricsForTask();
		}

		// initialize the readers.
		// this does not yet trigger any stream consuming or processing.
		initInputReaders();
		initBroadcastInputReaders();

		// initialize the writers.
		initOutputs();

		if (LOG.isDebugEnabled()) {
			LOG.debug(formatLogString("Finished registering input and output."));
		}

		// --------------------------------------------------------------------
		// Invoke
		// --------------------------------------------------------------------
		if (LOG.isDebugEnabled()) {
			LOG.debug(formatLogString("Start task code."));
		}

		this.runtimeUdfContext = createRuntimeContext(metrics);

		// whatever happens in this scope, make sure that the local strategies are cleaned up!
		// note that the initialization of the local strategies is in the try-finally block as well,
		// so that the thread that creates them catches its own errors that may happen in that process.
		// this is especially important, since there may be asynchronous closes (such as through canceling).
		try {
			// initialize the remaining data structures on the input and trigger the local processing
			// the local processing includes building the dams / caches
			try {
				int numInputs = driver.getNumberOfInputs();
				int numComparators = driver.getNumberOfDriverComparators();
				int numBroadcastInputs = this.config.getNumBroadcastInputs();
				
				initInputsSerializersAndComparators(numInputs, numComparators);
				initBroadcastInputsSerializers(numBroadcastInputs);
				
				// set the iterative status for inputs and broadcast inputs
				{
					List<Integer> iterativeInputs = new ArrayList<Integer>();
					
					for (int i = 0; i < numInputs; i++) {
						final int numberOfEventsUntilInterrupt = getTaskConfig().getNumberOfEventsUntilInterruptInIterativeGate(i);
			
						if (numberOfEventsUntilInterrupt < 0) {
							throw new IllegalArgumentException();
						}
						else if (numberOfEventsUntilInterrupt > 0) {
							this.inputReaders[i].setIterativeReader();
							iterativeInputs.add(i);
				
							if (LOG.isDebugEnabled()) {
								LOG.debug(formatLogString("Input [" + i + "] reads in supersteps with [" +
										+ numberOfEventsUntilInterrupt + "] event(s) till next superstep."));
							}
						}
					}
					this.iterativeInputs = asArray(iterativeInputs);
				}
				
				{
					List<Integer> iterativeBcInputs = new ArrayList<Integer>();
					
					for (int i = 0; i < numBroadcastInputs; i++) {
						final int numberOfEventsUntilInterrupt = getTaskConfig().getNumberOfEventsUntilInterruptInIterativeBroadcastGate(i);
						
						if (numberOfEventsUntilInterrupt < 0) {
							throw new IllegalArgumentException();
						}
						else if (numberOfEventsUntilInterrupt > 0) {
							this.broadcastInputReaders[i].setIterativeReader();
							iterativeBcInputs.add(i);
				
							if (LOG.isDebugEnabled()) {
								LOG.debug(formatLogString("Broadcast input [" + i + "] reads in supersteps with [" +
										+ numberOfEventsUntilInterrupt + "] event(s) till next superstep."));
							}
						}
					}
					this.iterativeBroadcastInputs = asArray(iterativeBcInputs);
				}
				
				initLocalStrategies(numInputs);
			}
			catch (Exception e) {
				throw new RuntimeException("Initializing the input processing failed" +
						(e.getMessage() == null ? "." : ": " + e.getMessage()), e);
			}

			if (!this.running) {
				if (LOG.isDebugEnabled()) {
					LOG.debug(formatLogString("Task cancelled before task code was started."));
				}
				return;
			}

			// pre main-function initialization
			initialize();

			// read the broadcast variables. they will be released in the finally clause 
			for (int i = 0; i < this.config.getNumBroadcastInputs(); i++) {
				final String name = this.config.getBroadcastInputName(i);
				readAndSetBroadcastInput(i, name, this.runtimeUdfContext, 1 /* superstep one for the start */);
			}

			// the work goes here
			run();
		}
		finally {
			// clean up in any case!
			closeLocalStrategiesAndCaches();

			clearReaders(inputReaders);
			clearWriters(eventualOutputs);

		}

		if (this.running) {
			if (LOG.isDebugEnabled()) {
				LOG.debug(formatLogString("Finished task code."));
			}
		} else {
			if (LOG.isDebugEnabled()) {
				LOG.debug(formatLogString("Task code cancelled."));
			}
		}
	}