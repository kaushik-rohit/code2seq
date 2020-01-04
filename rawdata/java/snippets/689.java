private boolean keyEquals(ByteBuffer curKeyBuffer, ByteBuffer buffer, int bufferOffset)
  {
    // Since this method is frequently called per each input row, the compare performance matters.
    int i = 0;
    for (; i + Long.BYTES <= keySize; i += Long.BYTES) {
      if (curKeyBuffer.getLong(i) != buffer.getLong(bufferOffset + i)) {
        return false;
      }
    }

    if (i + Integer.BYTES <= keySize) {
      // This can be called at most once because we already compared using getLong() in the above.
      if (curKeyBuffer.getInt(i) != buffer.getInt(bufferOffset + i)) {
        return false;
      }
      i += Integer.BYTES;
    }

    for (; i < keySize; i++) {
      if (curKeyBuffer.get(i) != buffer.get(bufferOffset + i)) {
        return false;
      }
    }

    return true;
  }