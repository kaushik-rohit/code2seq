public final void deleteLogMetric(MetricName metricName) {

    DeleteLogMetricRequest request =
        DeleteLogMetricRequest.newBuilder()
            .setMetricName(metricName == null ? null : metricName.toString())
            .build();
    deleteLogMetric(request);
  }