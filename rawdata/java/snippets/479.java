long calculateTruncationOffset(SegmentProperties info, long highestCopiedOffset) {
        long truncateOffset = -1;
        if (highestCopiedOffset > 0) {
            // Due to the nature of compaction (all entries are copied in order of their original versions), if we encounter
            // any copied Table Entries then the highest explicit version defined on any of them is where we can truncate.
            truncateOffset = highestCopiedOffset;
        } else if (this.indexReader.getLastIndexedOffset(info) >= info.getLength()) {
            // Did not encounter any copied entries. If we were able to index the whole segment, then we should be safe
            // to truncate at wherever the compaction last finished.
            truncateOffset = this.indexReader.getCompactionOffset(info);
        }

        if (truncateOffset <= info.getStartOffset()) {
            // The segment is already truncated at the compaction offset; no need for more.
            truncateOffset = -1;
        }

        return truncateOffset;
    }