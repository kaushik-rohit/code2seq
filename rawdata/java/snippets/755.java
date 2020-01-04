@WithBridgeMethods(List.class)
    @Deprecated
    public RunList<RunT> getBuildsByTimestamp(long start, long end) {
        return getBuilds().byTimestamp(start,end);
    }