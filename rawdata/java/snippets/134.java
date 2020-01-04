public static RpcService createRpcService(
			final Configuration configuration,
			final HighAvailabilityServices haServices) throws Exception {

		checkNotNull(configuration);
		checkNotNull(haServices);

		final String taskManagerAddress = determineTaskManagerBindAddress(configuration, haServices);
		final String portRangeDefinition = configuration.getString(TaskManagerOptions.RPC_PORT);

		return AkkaRpcServiceUtils.createRpcService(taskManagerAddress, portRangeDefinition, configuration);
	}