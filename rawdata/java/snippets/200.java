@BetaApi
  public final Operation startInstance(String instance) {

    StartInstanceHttpRequest request =
        StartInstanceHttpRequest.newBuilder().setInstance(instance).build();
    return startInstance(request);
  }