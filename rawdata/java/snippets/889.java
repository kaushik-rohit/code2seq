@BetaApi
  public final Policy setIamPolicySnapshot(
      ProjectGlobalSnapshotResourceName resource,
      GlobalSetPolicyRequest globalSetPolicyRequestResource) {

    SetIamPolicySnapshotHttpRequest request =
        SetIamPolicySnapshotHttpRequest.newBuilder()
            .setResource(resource == null ? null : resource.toString())
            .setGlobalSetPolicyRequestResource(globalSetPolicyRequestResource)
            .build();
    return setIamPolicySnapshot(request);
  }