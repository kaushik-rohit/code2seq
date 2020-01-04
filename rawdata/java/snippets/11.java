public Metric reloadAsync() throws ExecutionException, InterruptedException {
    // [START reloadAsync]
    Future<Metric> future = metric.reloadAsync();
    // ...
    Metric latestMetric = future.get();
    if (latestMetric == null) {
      // the metric was not found
    }
    // [END reloadAsync]
    return latestMetric;
  }