static ByteBuffer toFrame(ByteBuffer input, int dataSize) throws GeneralSecurityException {
    Preconditions.checkNotNull(input);
    if (dataSize > input.remaining()) {
      dataSize = input.remaining();
    }
    Producer producer = new Producer();
    ByteBuffer inputAlias = input.duplicate();
    inputAlias.limit(input.position() + dataSize);
    producer.readBytes(inputAlias);
    producer.flush();
    input.position(inputAlias.position());
    ByteBuffer output = producer.getRawFrame();
    return output;
  }