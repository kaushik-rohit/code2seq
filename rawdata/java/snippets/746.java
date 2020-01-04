@BetaApi
  public final NodeTemplate getNodeTemplate(ProjectRegionNodeTemplateName nodeTemplate) {

    GetNodeTemplateHttpRequest request =
        GetNodeTemplateHttpRequest.newBuilder()
            .setNodeTemplate(nodeTemplate == null ? null : nodeTemplate.toString())
            .build();
    return getNodeTemplate(request);
  }