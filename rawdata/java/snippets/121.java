@SuppressWarnings("WeakerAccess")
  public ApiFuture<Void> deleteInstanceAsync(String instanceId) {
    String instanceName = NameUtil.formatInstanceName(projectId, instanceId);

    com.google.bigtable.admin.v2.DeleteInstanceRequest request =
        com.google.bigtable.admin.v2.DeleteInstanceRequest.newBuilder()
            .setName(instanceName)
            .build();

    return ApiFutures.transform(
        stub.deleteInstanceCallable().futureCall(request),
        new ApiFunction<Empty, Void>() {
          @Override
          public Void apply(Empty input) {
            return null;
          }
        },
        MoreExecutors.directExecutor());
  }