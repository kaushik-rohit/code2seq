public ByteBuffer next(ByteBuffer inBytes) throws GeneralSecurityException {
    Preconditions.checkState(!isFinished(), "Handshake has already finished.");
    HandshakerReq.Builder req =
        HandshakerReq.newBuilder()
            .setNext(
                NextHandshakeMessageReq.newBuilder()
                    .setInBytes(ByteString.copyFrom(inBytes.duplicate()))
                    .build());
    HandshakerResp resp;
    try {
      resp = handshakerStub.send(req.build());
    } catch (IOException | InterruptedException e) {
      throw new GeneralSecurityException(e);
    }
    handleResponse(resp);
    inBytes.position(inBytes.position() + resp.getBytesConsumed());
    return resp.getOutFrames().asReadOnlyByteBuffer();
  }