public JobStatus.State reloadStatus() throws InterruptedException {
    // [START ]
    while (!JobStatus.State.DONE.equals(job.getStatus().getState())) {
      Thread.sleep(1000L);
      job = job.reload(BigQuery.JobOption.fields(BigQuery.JobField.STATUS));
    }
    // [END ]
    return job.getStatus().getState();
  }