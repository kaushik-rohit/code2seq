@BetaApi
  public final Operation enableXpnResourceProject(
      ProjectName project,
      ProjectsEnableXpnResourceRequest projectsEnableXpnResourceRequestResource) {

    EnableXpnResourceProjectHttpRequest request =
        EnableXpnResourceProjectHttpRequest.newBuilder()
            .setProject(project == null ? null : project.toString())
            .setProjectsEnableXpnResourceRequestResource(projectsEnableXpnResourceRequestResource)
            .build();
    return enableXpnResourceProject(request);
  }