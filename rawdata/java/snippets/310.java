void data(boolean outFinished, int streamId, Buffer source, boolean flush) {
    Preconditions.checkNotNull(source, "source");

    OkHttpClientStream stream = transport.getStream(streamId);
    if (stream == null) {
      // This is possible for a stream that has received end-of-stream from server (but hasn't sent
      // end-of-stream), and was removed from the transport stream map.
      // In such case, we just throw away the data.
      return;
    }

    OutboundFlowState state = state(stream);
    int window = state.writableWindow();
    boolean framesAlreadyQueued = state.hasPendingData();
    int size = (int) source.size();

    if (!framesAlreadyQueued && window >= size) {
      // Window size is large enough to send entire data frame
      state.write(source, size, outFinished);
    } else {
      // send partial data
      if (!framesAlreadyQueued && window > 0) {
        state.write(source, window, false);
      }
      // Queue remaining data in the buffer
      state.enqueue(source, (int) source.size(), outFinished);
    }

    if (flush) {
      flush();
    }
  }