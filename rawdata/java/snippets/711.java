private void waitForRebalance() throws InterruptedException {
        log.info("Waiting for {} seconds before attempting to rebalance", minRebalanceInterval.getSeconds());
        Thread.sleep(minRebalanceInterval.toMillis());
    }