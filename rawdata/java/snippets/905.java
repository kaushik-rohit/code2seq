private DistributionPattern connectJobVertices(Channel channel, int inputNumber,
			final JobVertex sourceVertex, final TaskConfig sourceConfig,
			final JobVertex targetVertex, final TaskConfig targetConfig, boolean isBroadcast)
	throws CompilerException
	{
		// ------------ connect the vertices to the job graph --------------
		final DistributionPattern distributionPattern;

		switch (channel.getShipStrategy()) {
			case FORWARD:
				distributionPattern = DistributionPattern.POINTWISE;
				break;
			case PARTITION_RANDOM:
			case BROADCAST:
			case PARTITION_HASH:
			case PARTITION_CUSTOM:
			case PARTITION_RANGE:
			case PARTITION_FORCED_REBALANCE:
				distributionPattern = DistributionPattern.ALL_TO_ALL;
				break;
			default:
				throw new RuntimeException("Unknown runtime ship strategy: " + channel.getShipStrategy());
		}

		final ResultPartitionType resultType;

		switch (channel.getDataExchangeMode()) {

			case PIPELINED:
				resultType = ResultPartitionType.PIPELINED;
				break;

			case BATCH:
				// BLOCKING results are currently not supported in closed loop iterations
				//
				// See https://issues.apache.org/jira/browse/FLINK-1713 for details
				resultType = channel.getSource().isOnDynamicPath()
						? ResultPartitionType.PIPELINED
						: ResultPartitionType.BLOCKING;
				break;

			case PIPELINE_WITH_BATCH_FALLBACK:
				throw new UnsupportedOperationException("Data exchange mode " +
						channel.getDataExchangeMode() + " currently not supported.");

			default:
				throw new UnsupportedOperationException("Unknown data exchange mode.");

		}

		JobEdge edge = targetVertex.connectNewDataSetAsInput(sourceVertex, distributionPattern, resultType);

		// -------------- configure the source task's ship strategy strategies in task config --------------
		final int outputIndex = sourceConfig.getNumOutputs();
		sourceConfig.addOutputShipStrategy(channel.getShipStrategy());
		if (outputIndex == 0) {
			sourceConfig.setOutputSerializer(channel.getSerializer());
		}
		if (channel.getShipStrategyComparator() != null) {
			sourceConfig.setOutputComparator(channel.getShipStrategyComparator(), outputIndex);
		}
		
		if (channel.getShipStrategy() == ShipStrategyType.PARTITION_RANGE) {
			
			final DataDistribution dataDistribution = channel.getDataDistribution();
			if (dataDistribution != null) {
				sourceConfig.setOutputDataDistribution(dataDistribution, outputIndex);
			} else {
				throw new RuntimeException("Range partitioning requires data distribution.");
			}
		}
		
		if (channel.getShipStrategy() == ShipStrategyType.PARTITION_CUSTOM) {
			if (channel.getPartitioner() != null) {
				sourceConfig.setOutputPartitioner(channel.getPartitioner(), outputIndex);
			} else {
				throw new CompilerException("The ship strategy was set to custom partitioning, but no partitioner was set.");
			}
		}
		
		// ---------------- configure the receiver -------------------
		if (isBroadcast) {
			targetConfig.addBroadcastInputToGroup(inputNumber);
		} else {
			targetConfig.addInputToGroup(inputNumber);
		}
		
		// ---------------- attach the additional infos to the job edge -------------------
		
		String shipStrategy = JsonMapper.getShipStrategyString(channel.getShipStrategy());
		if (channel.getShipStrategyKeys() != null && channel.getShipStrategyKeys().size() > 0) {
			shipStrategy += " on " + (channel.getShipStrategySortOrder() == null ?
					channel.getShipStrategyKeys().toString() :
					Utils.createOrdering(channel.getShipStrategyKeys(), channel.getShipStrategySortOrder()).toString());
		}
		
		String localStrategy;
		if (channel.getLocalStrategy() == null || channel.getLocalStrategy() == LocalStrategy.NONE) {
			localStrategy = null;
		}
		else {
			localStrategy = JsonMapper.getLocalStrategyString(channel.getLocalStrategy());
			if (localStrategy != null && channel.getLocalStrategyKeys() != null && channel.getLocalStrategyKeys().size() > 0) {
				localStrategy += " on " + (channel.getLocalStrategySortOrder() == null ?
						channel.getLocalStrategyKeys().toString() :
						Utils.createOrdering(channel.getLocalStrategyKeys(), channel.getLocalStrategySortOrder()).toString());
			}
		}
		
		String caching = channel.getTempMode() == TempMode.NONE ? null : channel.getTempMode().toString();

		edge.setShipStrategyName(shipStrategy);
		edge.setPreProcessingOperationName(localStrategy);
		edge.setOperatorLevelCachingDescription(caching);
		
		return distributionPattern;
	}