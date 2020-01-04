@Override
  public void close() throws IOException {
    if (open) {
      // stop accepting work, interrupt worker thread.
      exec.shutdownNow();
      try {
        // give worker thread a bit of time to process the interruption.
        exec.awaitTermination(1, TimeUnit.SECONDS);
      } catch (InterruptedException e) {
        // Restore interrupted status
        Thread.currentThread().interrupt();
      }
      chan.close();
      open = false;
    }
  }