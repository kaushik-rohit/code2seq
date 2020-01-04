public Page<Dataset> listDatasets() {
    // [START bigquery_list_datasets]
    // List datasets in the default project
    Page<Dataset> datasets = bigquery.listDatasets(DatasetListOption.pageSize(100));
    for (Dataset dataset : datasets.iterateAll()) {
      // do something with the dataset
    }
    // [END bigquery_list_datasets]
    return datasets;
  }