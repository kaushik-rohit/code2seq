protected V putNoCopyOrAwait(K key, V value, boolean publishToWriter, int[] puts) {
    requireNonNull(key);
    requireNonNull(value);

    @SuppressWarnings("unchecked")
    V[] replaced = (V[]) new Object[1];
    cache.asMap().compute(copyOf(key), (k, expirable) -> {
      V newValue = copyOf(value);
      if (publishToWriter && configuration.isWriteThrough()) {
        publishToCacheWriter(writer::write, () -> new EntryProxy<>(key, value));
      }
      if ((expirable != null) && !expirable.isEternal()
          && expirable.hasExpired(currentTimeMillis())) {
        dispatcher.publishExpired(this, key, expirable.get());
        statistics.recordEvictions(1L);
        expirable = null;
      }
      long expireTimeMS = getWriteExpireTimeMS((expirable == null));
      if ((expirable != null) && (expireTimeMS == Long.MIN_VALUE)) {
        expireTimeMS = expirable.getExpireTimeMS();
      }
      if (expireTimeMS == 0) {
        replaced[0] = (expirable == null) ? null : expirable.get();
        return null;
      } else if (expirable == null) {
        dispatcher.publishCreated(this, key, newValue);
      } else {
        replaced[0] = expirable.get();
        dispatcher.publishUpdated(this, key, expirable.get(), newValue);
      }
      puts[0]++;
      return new Expirable<>(newValue, expireTimeMS);
    });
    return replaced[0];
  }