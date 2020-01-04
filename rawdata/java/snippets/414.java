@Override
    public List<MetricFamilySamples> collect() {

        final GaugeMetricFamily states = new GaugeMetricFamily(
                prefix + "_states",
                "Circuit Breaker States",
                asList("name","state"));

        final GaugeMetricFamily calls = new GaugeMetricFamily(
                prefix + "_calls",
                "Circuit Breaker Call Stats",
                asList("name", "call_result"));

        for (CircuitBreaker circuitBreaker : circuitBreakersSupplier.get()) {

            STATE_NAME_MAP.forEach(e -> {
                final CircuitBreaker.State state = e._1;
                final String name = e._2;
                final double value = state == circuitBreaker.getState() ? 1.0 : 0.0;

                states.addMetric(asList(circuitBreaker.getName(), name), value);
            });

            final CircuitBreaker.Metrics metrics = circuitBreaker.getMetrics();

            calls.addMetric(
                    asList(circuitBreaker.getName(), "successful"),
                    metrics.getNumberOfSuccessfulCalls());

            calls.addMetric(
                    asList(circuitBreaker.getName(), "failed"),
                    metrics.getNumberOfFailedCalls());

            calls.addMetric(
                    asList(circuitBreaker.getName(), "not_permitted"),
                    metrics.getNumberOfNotPermittedCalls());

            calls.addMetric(
                    asList(circuitBreaker.getName(), "buffered"),
                    metrics.getNumberOfBufferedCalls());

            calls.addMetric(
                    asList(circuitBreaker.getName(), "buffered_max"),
                    metrics.getMaxNumberOfBufferedCalls());
        }

        return asList(calls, states);
    }