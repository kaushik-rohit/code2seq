public static ServerServiceDefinition interceptForward(ServerServiceDefinition serviceDef,
                                                         ServerInterceptor... interceptors) {
    return interceptForward(serviceDef, Arrays.asList(interceptors));
  }