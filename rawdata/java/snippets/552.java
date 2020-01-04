public <T> Iterable<T> removeAll(Key<T> key) {
    if (isEmpty()) {
      return null;
    }
    int writeIdx = 0;
    int readIdx = 0;
    List<T> ret = null;
    for (; readIdx < size; readIdx++) {
      if (bytesEqual(key.asciiName(), name(readIdx))) {
        ret = ret != null ? ret : new ArrayList<T>();
        ret.add(key.parseBytes(value(readIdx)));
        continue;
      }
      name(writeIdx, name(readIdx));
      value(writeIdx, value(readIdx));
      writeIdx++;
    }
    int newSize = writeIdx;
    // Multiply by two since namesAndValues is interleaved.
    Arrays.fill(namesAndValues, writeIdx * 2, len(), null);
    size = newSize;
    return ret;
  }