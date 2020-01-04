@BetaApi
  public final RouterStatusResponse getRouterStatusRouter(ProjectRegionRouterName router) {

    GetRouterStatusRouterHttpRequest request =
        GetRouterStatusRouterHttpRequest.newBuilder()
            .setRouter(router == null ? null : router.toString())
            .build();
    return getRouterStatusRouter(request);
  }