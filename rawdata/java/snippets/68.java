public static int getMaxConcurrentRunsForFlow(String projectName, String flowName,
      int defaultMaxConcurrentRuns, Map<Pair<String, String>, Integer> maxConcurrentRunsFlowMap) {
      return maxConcurrentRunsFlowMap.getOrDefault(new Pair(projectName, flowName),
          defaultMaxConcurrentRuns);
  }