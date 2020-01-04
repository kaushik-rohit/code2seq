public final BatchAnnotateImagesResponse batchAnnotateImages(
      List<AnnotateImageRequest> requests) {

    BatchAnnotateImagesRequest request =
        BatchAnnotateImagesRequest.newBuilder().addAllRequests(requests).build();
    return batchAnnotateImages(request);
  }