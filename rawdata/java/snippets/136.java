@BetaApi
  public final ListInterconnectLocationsPagedResponse listInterconnectLocations(String project) {
    ListInterconnectLocationsHttpRequest request =
        ListInterconnectLocationsHttpRequest.newBuilder().setProject(project).build();
    return listInterconnectLocations(request);
  }