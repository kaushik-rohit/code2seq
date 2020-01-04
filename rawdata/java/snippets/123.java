private InMemoryMetricEmitter extractInMemoryMetricEmitter(
      final MetricReportManager metricManager) {
    InMemoryMetricEmitter memoryEmitter = null;
    for (final IMetricEmitter emitter : metricManager.getMetricEmitters()) {
      if (emitter instanceof InMemoryMetricEmitter) {
        memoryEmitter = (InMemoryMetricEmitter) emitter;
        break;
      }
    }
    return memoryEmitter;
  }