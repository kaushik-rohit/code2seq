@BetaApi(
      "The surface for long-running operations is not stable yet and may change in the future.")
  public final OperationFuture<AnnotateVideoResponse, AnnotateVideoProgress> annotateVideoAsync(
      String inputUri, List<Feature> features) {

    AnnotateVideoRequest request =
        AnnotateVideoRequest.newBuilder().setInputUri(inputUri).addAllFeatures(features).build();
    return annotateVideoAsync(request);
  }