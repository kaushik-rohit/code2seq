@BetaApi
  public final ListRegionAutoscalersPagedResponse listRegionAutoscalers(ProjectRegionName region) {
    ListRegionAutoscalersHttpRequest request =
        ListRegionAutoscalersHttpRequest.newBuilder()
            .setRegion(region == null ? null : region.toString())
            .build();
    return listRegionAutoscalers(request);
  }