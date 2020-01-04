private void process(long key) {
    IntPriorityQueue times = accessTimes.get(key);

    int lastAccess = times.dequeueInt();
    boolean found = data.remove(lastAccess);

    if (times.isEmpty()) {
      data.add(infiniteTimestamp--);
      accessTimes.remove(key);
    } else {
      data.add(times.firstInt());
    }
    if (found) {
      policyStats.recordHit();
    } else {
      policyStats.recordMiss();
      if (data.size() > maximumSize) {
        evict();
      }
    }
  }