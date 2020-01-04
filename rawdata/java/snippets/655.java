public final void deleteInstance(InstanceName name) {

    DeleteInstanceRequest request =
        DeleteInstanceRequest.newBuilder().setName(name == null ? null : name.toString()).build();
    deleteInstance(request);
  }