public void toBytes(ByteBuffer buf)
  {
    if (canStoreCompact() && getCompactStorageSize() < getSparseStorageSize()) {
      // store compact
      toBytesCompact(buf);
    } else {
      // store sparse
      toBytesSparse(buf);
    }
  }