public static void writeToStream(BitMatrix matrix, String format, OutputStream stream) throws IOException {
    writeToStream(matrix, format, stream, DEFAULT_CONFIG);
  }