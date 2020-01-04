static Finding setFindingState(FindingName findingName) {
    try (SecurityCenterClient client = SecurityCenterClient.create()) {
      // FindingName findingName = FindingName.of(/*organization=*/"123234324",
      // /*source=*/"423432321", /*findingId=*/"samplefindingid2");

      // Use the current time as the finding "event time".
      Instant eventTime = Instant.now();

      Finding response =
          client.setFindingState(
              findingName,
              State.INACTIVE,
              Timestamp.newBuilder()
                  .setSeconds(eventTime.getEpochSecond())
                  .setNanos(eventTime.getNano())
                  .build());

      System.out.println("Updated Finding: " + response);
      return response;
    } catch (IOException e) {
      throw new RuntimeException("Couldn't create client.", e);
    }
  }