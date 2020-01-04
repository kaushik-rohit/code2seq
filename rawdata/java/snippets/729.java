@BetaApi
  public final Operation insertGlobalAddress(ProjectName project, Address addressResource) {

    InsertGlobalAddressHttpRequest request =
        InsertGlobalAddressHttpRequest.newBuilder()
            .setProject(project == null ? null : project.toString())
            .setAddressResource(addressResource)
            .build();
    return insertGlobalAddress(request);
  }