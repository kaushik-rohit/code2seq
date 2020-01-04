@BetaApi
  public final ListTargetHttpsProxiesPagedResponse listTargetHttpsProxies(String project) {
    ListTargetHttpsProxiesHttpRequest request =
        ListTargetHttpsProxiesHttpRequest.newBuilder().setProject(project).build();
    return listTargetHttpsProxies(request);
  }