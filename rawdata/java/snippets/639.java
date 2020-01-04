public void createTransaction(String scope, String streamName, Duration latency) {
        DYNAMIC_LOGGER.incCounterValue(globalMetricName(CREATE_TRANSACTION), 1);
        DYNAMIC_LOGGER.incCounterValue(CREATE_TRANSACTION, 1, streamTags(scope, streamName));
        createTransactionLatency.reportSuccessValue(latency.toMillis());
    }