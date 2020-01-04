@Override
  public String ltrim(final byte[] key, final long start, final long stop) {
    checkIsInMultiOrPipeline();
    client.ltrim(key, start, stop);
    return client.getStatusCodeReply();
  }