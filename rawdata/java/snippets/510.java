public static Dependencies create(long startTs, long endTs, List<DependencyLink> links) {
    return new Dependencies(startTs, endTs, links);
  }