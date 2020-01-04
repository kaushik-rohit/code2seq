public <T> DynamicResult<T> createResult(Environment env, TableSchema schema, ExecutionConfig config) {

		final RowTypeInfo outputType = new RowTypeInfo(schema.getFieldTypes(), schema.getFieldNames());

		if (env.getExecution().isStreamingExecution()) {
			// determine gateway address (and port if possible)
			final InetAddress gatewayAddress = getGatewayAddress(env.getDeployment());
			final int gatewayPort = getGatewayPort(env.getDeployment());

			if (env.getExecution().isChangelogMode()) {
				return new ChangelogCollectStreamResult<>(outputType, config, gatewayAddress, gatewayPort);
			} else {
				return new MaterializedCollectStreamResult<>(
					outputType,
					config,
					gatewayAddress,
					gatewayPort,
					env.getExecution().getMaxTableResultRows());
			}

		} else {
			// Batch Execution
			if (!env.getExecution().isTableMode()) {
				throw new SqlExecutionException("Results of batch queries can only be served in table mode.");
			}
			return new MaterializedCollectBatchResult<>(outputType, config);
		}
	}