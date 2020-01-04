@Override
    public void visit(JunitXmlReport report) {

        int testsPassed = report.getTests() - report.getFailures() - report.getErrors();

        Map<String, Pair<Integer, CodeQualityMetricStatus>> metricsMap = new HashMap<>();
        metricsMap.put(TOTAL_NO_OF_TESTS, Pair.of(report.getTests(), CodeQualityMetricStatus.Ok));
        metricsMap.put(TEST_FAILURES, Pair.of(report.getFailures(), report.getFailures() > 0 ? CodeQualityMetricStatus.Warning : CodeQualityMetricStatus.Ok));
        metricsMap.put(TEST_ERRORS, Pair.of(report.getErrors(), report.getErrors() > 0 ? CodeQualityMetricStatus.Alert : CodeQualityMetricStatus.Ok));
        metricsMap.put(TEST_SUCCESS_DENSITY, Pair.of(testsPassed, CodeQualityMetricStatus.Ok));

        if (null != report.getTimestamp()) {
            long timestamp = Math.max(quality.getTimestamp(), report.getTimestamp().toGregorianCalendar().getTimeInMillis());
            quality.setTimestamp(timestamp);
        }
        quality.setType(CodeQualityType.StaticAnalysis);

        // finally produce the result
        this.sumMetrics(metricsMap);

    }