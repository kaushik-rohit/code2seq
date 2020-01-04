@BetaApi
  public final Operation removeHealthCheckTargetPool(
      ProjectRegionTargetPoolName targetPool,
      TargetPoolsRemoveHealthCheckRequest targetPoolsRemoveHealthCheckRequestResource) {

    RemoveHealthCheckTargetPoolHttpRequest request =
        RemoveHealthCheckTargetPoolHttpRequest.newBuilder()
            .setTargetPool(targetPool == null ? null : targetPool.toString())
            .setTargetPoolsRemoveHealthCheckRequestResource(
                targetPoolsRemoveHealthCheckRequestResource)
            .build();
    return removeHealthCheckTargetPool(request);
  }