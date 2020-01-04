long expireAfterUpdate(Node<K, V> node, @Nullable K key,
      @Nullable V value, Expiry<K, V> expiry, long now) {
    if (expiresVariable() && (key != null) && (value != null)) {
      long currentDuration = Math.max(1, node.getVariableTime() - now);
      long duration = expiry.expireAfterUpdate(key, value, now, currentDuration);
      return isAsync ? (now + duration) : (now + Math.min(duration, MAXIMUM_EXPIRY));
    }
    return 0L;
  }