static Deadline after(long duration, TimeUnit units, Ticker ticker) {
    checkNotNull(units, "units");
    return new Deadline(ticker, units.toNanos(duration), true);
  }