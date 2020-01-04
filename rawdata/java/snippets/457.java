@BetaApi
  public final Operation insertSslPolicy(ProjectName project, SslPolicy sslPolicyResource) {

    InsertSslPolicyHttpRequest request =
        InsertSslPolicyHttpRequest.newBuilder()
            .setProject(project == null ? null : project.toString())
            .setSslPolicyResource(sslPolicyResource)
            .build();
    return insertSslPolicy(request);
  }