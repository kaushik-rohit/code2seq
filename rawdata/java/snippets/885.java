public final GenerateAccessTokenResponse generateAccessToken(
      ServiceAccountName name, List<String> delegates, List<String> scope, Duration lifetime) {

    GenerateAccessTokenRequest request =
        GenerateAccessTokenRequest.newBuilder()
            .setName(name == null ? null : name.toString())
            .addAllDelegates(delegates)
            .addAllScope(scope)
            .setLifetime(lifetime)
            .build();
    return generateAccessToken(request);
  }