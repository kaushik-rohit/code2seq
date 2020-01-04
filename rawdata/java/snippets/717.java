private List<MergedIndexEntry> getAllEntries(long offsetAdjustment) {
        Exceptions.checkArgument(offsetAdjustment >= 0, "offsetAdjustment", "offsetAdjustment must be a non-negative number.");

        synchronized (this.lock) {
            List<MergedIndexEntry> result = new ArrayList<>(this.indexEntries.size());
            this.indexEntries.forEach(entry -> {
                if (entry.isDataEntry()) {
                    result.add(new MergedIndexEntry(entry.getStreamSegmentOffset() + offsetAdjustment, this.metadata.getId(), (CacheIndexEntry) entry));
                }
            });

            return result;
        }
    }