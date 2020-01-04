@Deprecated
  public RequestTemplate method(String method) {
    checkNotNull(method, "method");
    try {
      this.method = HttpMethod.valueOf(method);
    } catch (IllegalArgumentException iae) {
      throw new IllegalArgumentException("Invalid HTTP Method: " + method);
    }
    return this;
  }