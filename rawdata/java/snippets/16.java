@Nullable V removeNoWriter(Object key) {
    Node<K, V> node = data.remove(nodeFactory.newLookupKey(key));
    if (node == null) {
      return null;
    }

    V oldValue;
    synchronized (node) {
      oldValue = node.getValue();
      if (node.isAlive()) {
        node.retire();
      }
    }

    RemovalCause cause;
    if (oldValue == null) {
      cause = RemovalCause.COLLECTED;
    } else if (hasExpired(node, expirationTicker().read())) {
      cause = RemovalCause.EXPIRED;
    } else {
      cause = RemovalCause.EXPLICIT;
    }

    if (hasRemovalListener()) {
      @SuppressWarnings("unchecked")
      K castKey = (K) key;
      notifyRemoval(castKey, oldValue, cause);
    }
    afterWrite(new RemovalTask(node));
    return (cause == RemovalCause.EXPLICIT) ? oldValue : null;
  }