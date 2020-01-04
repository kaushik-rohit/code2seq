protected Map<K, Expirable<V>> getAndFilterExpiredEntries(
      Set<? extends K> keys, boolean updateAccessTime) {
    Map<K, Expirable<V>> result = new HashMap<>(cache.getAllPresent(keys));

    int[] expired = { 0 };
    long[] millis = { 0L };
    result.entrySet().removeIf(entry -> {
      if (!entry.getValue().isEternal() && (millis[0] == 0L)) {
        millis[0] = currentTimeMillis();
      }
      if (entry.getValue().hasExpired(millis[0])) {
        cache.asMap().computeIfPresent(entry.getKey(), (k, expirable) -> {
          if (expirable == entry.getValue()) {
            dispatcher.publishExpired(this, entry.getKey(), entry.getValue().get());
            expired[0]++;
            return null;
          }
          return expirable;
        });
        return true;
      }
      if (updateAccessTime) {
        setAccessExpirationTime(entry.getValue(), millis[0]);
      }
      return false;
    });

    statistics.recordHits(result.size());
    statistics.recordMisses(keys.size() - result.size());
    statistics.recordEvictions(expired[0]);
    return result;
  }