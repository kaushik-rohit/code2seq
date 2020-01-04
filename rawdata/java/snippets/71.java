public void add(List<BatchCSVRecord> record) {
        if (records == null)
            records = new ArrayList<>();
        records.add(record);
    }