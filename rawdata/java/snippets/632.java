public static String getHeaderSegmentName(String segmentName) {
        Preconditions.checkArgument(!segmentName.endsWith(HEADER_SUFFIX), "segmentName is already a segment header name");
        return segmentName + HEADER_SUFFIX;
    }