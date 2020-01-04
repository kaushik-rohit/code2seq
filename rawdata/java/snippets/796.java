public static byte[] readArray(ReadableBuffer buffer) {
    Preconditions.checkNotNull(buffer, "buffer");
    int length = buffer.readableBytes();
    byte[] bytes = new byte[length];
    buffer.readBytes(bytes, 0, length);
    return bytes;
  }