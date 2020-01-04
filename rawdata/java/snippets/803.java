private int findKey(K key) {
    int i = 0;
    for (K otherKey : this.keys) {
      if (this.comparator.compare(key, otherKey) == 0) {
        return i;
      }
      i++;
    }
    return -1;
  }