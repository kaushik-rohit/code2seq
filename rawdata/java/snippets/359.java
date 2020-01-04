public void streamClosed(Status status) {
    if (closed.compareAndSet(false, true)) {
      for (StreamTracer tracer : tracers) {
        tracer.streamClosed(status);
      }
    }
  }