public final void deleteJob(String name) {

    DeleteJobRequest request = DeleteJobRequest.newBuilder().setName(name).build();
    deleteJob(request);
  }