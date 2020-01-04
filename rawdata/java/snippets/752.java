@BetaApi
  public final Operation patchNetwork(
      ProjectGlobalNetworkName network, Network networkResource, List<String> fieldMask) {

    PatchNetworkHttpRequest request =
        PatchNetworkHttpRequest.newBuilder()
            .setNetwork(network == null ? null : network.toString())
            .setNetworkResource(networkResource)
            .addAllFieldMask(fieldMask)
            .build();
    return patchNetwork(request);
  }