public final Queue createQueue(String parent, Queue queue) {

    CreateQueueRequest request =
        CreateQueueRequest.newBuilder().setParent(parent).setQueue(queue).build();
    return createQueue(request);
  }