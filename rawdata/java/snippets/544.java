public final void acknowledgeTask(String name, Timestamp scheduleTime) {

    AcknowledgeTaskRequest request =
        AcknowledgeTaskRequest.newBuilder().setName(name).setScheduleTime(scheduleTime).build();
    acknowledgeTask(request);
  }