public MockResponse addHeader(String name, Object value) {
    headers.add(name, String.valueOf(value));
    return this;
  }