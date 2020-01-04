static SegmentChunk forSegment(String segmentName, long startOffset) {
        return new SegmentChunk(StreamSegmentNameUtils.getSegmentChunkName(segmentName, startOffset), startOffset);
    }