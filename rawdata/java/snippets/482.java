@ExperimentalApi("https://github.com/grpc/grpc-java/issues/1704")
  public final S withCompression(String compressorName) {
    return build(channel, callOptions.withCompression(compressorName));
  }