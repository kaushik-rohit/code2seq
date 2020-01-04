public void collectClient(RpcClientLookoutModel rpcClientMetricsModel) {

        try {
            Id methodConsumerId = createMethodConsumerId(rpcClientMetricsModel);
            MixinMetric methodConsumerMetric = Lookout.registry().mixinMetric(methodConsumerId);

            recordCounterAndTimer(methodConsumerMetric, rpcClientMetricsModel);

            recordSize(methodConsumerMetric, rpcClientMetricsModel);

        } catch (Throwable t) {
            LOGGER.error(LogCodes.getLog(LogCodes.ERROR_METRIC_REPORT_ERROR), t);
        }
    }