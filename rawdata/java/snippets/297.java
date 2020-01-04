public final TableSpec updateTableSpec(TableSpec tableSpec) {

    UpdateTableSpecRequest request =
        UpdateTableSpecRequest.newBuilder().setTableSpec(tableSpec).build();
    return updateTableSpec(request);
  }