public int connectionTimeoutMs() {
    long defaultNetworkTimeoutS = JavaUtils.timeStringAsSec(
      conf.get("spark.network.timeout", "120s"));
    long defaultTimeoutMs = JavaUtils.timeStringAsSec(
      conf.get(SPARK_NETWORK_IO_CONNECTIONTIMEOUT_KEY, defaultNetworkTimeoutS + "s")) * 1000;
    return (int) defaultTimeoutMs;
  }