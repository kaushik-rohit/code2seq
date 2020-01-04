@NonNull
  public <K1 extends K, V1 extends V> AsyncLoadingCache<K1, V1> buildAsync(
      @NonNull CacheLoader<? super K1, V1> loader) {
    return buildAsync((AsyncCacheLoader<? super K1, V1>) loader);
  }