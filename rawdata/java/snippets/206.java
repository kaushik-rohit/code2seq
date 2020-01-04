@Benchmark
  @BenchmarkMode(Mode.SampleTime)
  @OutputTimeUnit(TimeUnit.NANOSECONDS)
  public String messageDecodePlain() {
    return Status.MESSAGE_KEY.parseBytes(
        "Unexpected RST in stream".getBytes(Charset.forName("US-ASCII")));
  }