public static StreamSegmentReadResult read(SegmentProperties segmentInfo, long startOffset, int maxReadLength, int readBlockSize, ReadOnlyStorage storage) {
        Exceptions.checkArgument(startOffset >= 0, "startOffset", "startOffset must be a non-negative number.");
        Exceptions.checkArgument(maxReadLength >= 0, "maxReadLength", "maxReadLength must be a non-negative number.");
        Preconditions.checkNotNull(segmentInfo, "segmentInfo");
        Preconditions.checkNotNull(storage, "storage");
        String traceId = String.format("Read[%s]", segmentInfo.getName());
        return new StreamSegmentReadResult(startOffset, maxReadLength, new SegmentReader(segmentInfo, null, readBlockSize, storage), traceId);
    }