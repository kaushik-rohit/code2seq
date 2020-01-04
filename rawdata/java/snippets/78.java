public static ServerServiceDefinition interceptForward(
      ServerServiceDefinition serviceDef,
      List<? extends ServerInterceptor> interceptors) {
    List<? extends ServerInterceptor> copy = new ArrayList<>(interceptors);
    Collections.reverse(copy);
    return intercept(serviceDef, copy);
  }