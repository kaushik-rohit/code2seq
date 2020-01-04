public final ListLogEntriesPagedResponse listLogEntries(
      List<String> resourceNames, String filter, String orderBy) {
    ListLogEntriesRequest request =
        ListLogEntriesRequest.newBuilder()
            .addAllResourceNames(resourceNames)
            .setFilter(filter)
            .setOrderBy(orderBy)
            .build();
    return listLogEntries(request);
  }