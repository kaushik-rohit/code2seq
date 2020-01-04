public final Application createApplication(String parent, Application application) {

    CreateApplicationRequest request =
        CreateApplicationRequest.newBuilder().setParent(parent).setApplication(application).build();
    return createApplication(request);
  }