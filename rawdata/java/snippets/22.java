private void readMessage() throws IOException {
    while (true) {
      if (closed) throw new IOException("closed");

      if (frameLength > 0) {
        source.readFully(messageFrameBuffer, frameLength);

        if (!isClient) {
          messageFrameBuffer.readAndWriteUnsafe(maskCursor);
          maskCursor.seek(messageFrameBuffer.size() - frameLength);
          toggleMask(maskCursor, maskKey);
          maskCursor.close();
        }
      }

      if (isFinalFrame) break; // We are exhausted and have no continuations.

      readUntilNonControlFrame();
      if (opcode != OPCODE_CONTINUATION) {
        throw new ProtocolException("Expected continuation opcode. Got: " + toHexString(opcode));
      }
    }
  }