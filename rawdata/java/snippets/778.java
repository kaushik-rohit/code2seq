public SDVariable variance(String name, @NonNull SDVariable x, boolean biasCorrected, int... dimensions) {
        return variance(name, x, biasCorrected, false, dimensions);
    }