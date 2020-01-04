public static void newBuilder(String projectId, String topicId) throws Exception {
    ProjectTopicName topic = ProjectTopicName.of(projectId, topicId);
    Publisher publisher = Publisher.newBuilder(topic).build();
    try {
      // ...
    } finally {
      // When finished with the publisher, make sure to shutdown to free up resources.
      publisher.shutdown();
      publisher.awaitTermination(1, TimeUnit.MINUTES);
    }
  }