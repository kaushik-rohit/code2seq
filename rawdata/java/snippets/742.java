@Benchmark
  @BenchmarkMode(Mode.AverageTime)
  @OutputTimeUnit(TimeUnit.NANOSECONDS)
  public void grpcHeaders_serverHandler(Blackhole bh) {
    serverHandler(bh, new GrpcHttp2RequestHeaders(4));
  }