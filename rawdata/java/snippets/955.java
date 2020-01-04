public void undeleteTable(String datasetId) throws InterruptedException {
    generateTableWithDdl(datasetId, "oops_undelete_me");

    // [START bigquery_undelete_table]
    // String datasetId = "my_dataset";
    String tableId = "oops_undelete_me";

    // Record the current time.  We'll use this as the snapshot time
    // for recovering the table.
    long snapTime = Instant.now().toEpochMilli();

    // "Accidentally" delete the table.
    bigquery.delete(TableId.of(datasetId, tableId));

    // Construct the restore-from tableID using a snapshot decorator.
    String snapshotTableId = String.format("%s@%d", tableId, snapTime);
    // Choose a new table ID for the recovered table data.
    String recoverTableId = String.format("%s_recovered", tableId);

    // Construct and run a copy job.
    CopyJobConfiguration configuration =
        CopyJobConfiguration.newBuilder(
                TableId.of(datasetId, recoverTableId), TableId.of(datasetId, snapshotTableId))
            .build();
    Job job = bigquery.create(JobInfo.of(configuration));
    job = job.waitFor();

    // Check the table
    StandardTableDefinition table =
        bigquery.getTable(TableId.of(datasetId, recoverTableId)).getDefinition();
    System.out.println("State: " + job.getStatus().getState());
    System.out.printf("Recovered %d rows.\n", table.getNumRows());
    // [END bigquery_undelete_table]
  }