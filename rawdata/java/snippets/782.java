@BetaApi
  public final Operation deleteImage(ProjectGlobalImageName image) {

    DeleteImageHttpRequest request =
        DeleteImageHttpRequest.newBuilder()
            .setImage(image == null ? null : image.toString())
            .build();
    return deleteImage(request);
  }