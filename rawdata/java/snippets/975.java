public void createTransactionFailed(String scope, String streamName) {
        DYNAMIC_LOGGER.incCounterValue(globalMetricName(CREATE_TRANSACTION_FAILED), 1);
        DYNAMIC_LOGGER.incCounterValue(CREATE_TRANSACTION_FAILED, 1, streamTags(scope, streamName));
    }