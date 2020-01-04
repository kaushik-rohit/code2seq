public boolean deleteMetricAsync(String metricName)
      throws ExecutionException, InterruptedException {
    // [START deleteMetricAsync]
    Future<Boolean> future = logging.deleteMetricAsync(metricName);
    // ...
    boolean deleted = future.get();
    if (deleted) {
      // the metric was deleted
    } else {
      // the metric was not found
    }
    // [END deleteMetricAsync]
    return deleted;
  }