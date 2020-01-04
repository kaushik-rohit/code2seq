public double computeRightEntropy(PairFrequency pair)
    {
        Set<Map.Entry<String, TriaFrequency>> entrySet = trieTria.prefixSearch(pair.getKey() + RIGHT);
        return computeEntropy(entrySet);
    }