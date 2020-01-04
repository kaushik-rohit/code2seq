static Finding updateFinding(FindingName findingName) {
    try (SecurityCenterClient client = SecurityCenterClient.create()) {
      // FindingName findingName = FindingName.of(/*organization=*/"123234324",
      // /*source=*/"423432321", /*findingId=*/"samplefindingid2");

      // Use the current time as the finding "event time".
      Instant eventTime = Instant.now();

      // Define source properties values as protobuf "Value" objects.
      Value stringValue = Value.newBuilder().setStringValue("value").build();

      FieldMask updateMask =
          FieldMask.newBuilder()
              .addPaths("event_time")
              .addPaths("source_properties.stringKey")
              .build();

      Finding finding =
          Finding.newBuilder()
              .setName(findingName.toString())
              .setEventTime(
                  Timestamp.newBuilder()
                      .setSeconds(eventTime.getEpochSecond())
                      .setNanos(eventTime.getNano()))
              .putSourceProperties("stringKey", stringValue)
              .build();

      UpdateFindingRequest.Builder request =
          UpdateFindingRequest.newBuilder().setFinding(finding).setUpdateMask(updateMask);

      // Call the API.
      Finding response = client.updateFinding(request.build());

      System.out.println("Updated Finding: " + response);
      return response;
    } catch (IOException e) {
      throw new RuntimeException("Couldn't create client.", e);
    }
  }