protected void stop(String[] args) throws Exception {
		LOG.info("Running 'stop-with-savepoint' command.");

		final Options commandOptions = CliFrontendParser.getStopCommandOptions();
		final Options commandLineOptions = CliFrontendParser.mergeOptions(commandOptions, customCommandLineOptions);
		final CommandLine commandLine = CliFrontendParser.parse(commandLineOptions, args, false);

		final StopOptions stopOptions = new StopOptions(commandLine);
		if (stopOptions.isPrintHelp()) {
			CliFrontendParser.printHelpForStop(customCommandLines);
			return;
		}

		final String[] cleanedArgs = stopOptions.getArgs();

		final String targetDirectory = stopOptions.hasSavepointFlag() && cleanedArgs.length > 0
				? stopOptions.getTargetDirectory()
				: null; // the default savepoint location is going to be used in this case.

		final JobID jobId = cleanedArgs.length != 0
				? parseJobId(cleanedArgs[0])
				: parseJobId(stopOptions.getTargetDirectory());

		final boolean advanceToEndOfEventTime = stopOptions.shouldAdvanceToEndOfEventTime();

		logAndSysout((advanceToEndOfEventTime ? "Draining job " : "Suspending job ") + "\"" + jobId + "\" with a savepoint.");

		final CustomCommandLine<?> activeCommandLine = getActiveCustomCommandLine(commandLine);
		runClusterAction(
			activeCommandLine,
			commandLine,
			clusterClient -> {
				try {
					clusterClient.stopWithSavepoint(jobId, advanceToEndOfEventTime, targetDirectory);
				} catch (Exception e) {
					throw new FlinkException("Could not stop with a savepoint job \"" + jobId + "\".", e);
				}
			});

		logAndSysout((advanceToEndOfEventTime ? "Drained job " : "Suspended job ") + "\"" + jobId + "\" with a savepoint.");
	}