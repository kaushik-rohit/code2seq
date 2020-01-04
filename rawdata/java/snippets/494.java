@BetaApi
  public final ListUsableSubnetworksPagedResponse listUsableSubnetworks(ProjectName project) {
    ListUsableSubnetworksHttpRequest request =
        ListUsableSubnetworksHttpRequest.newBuilder()
            .setProject(project == null ? null : project.toString())
            .build();
    return listUsableSubnetworks(request);
  }