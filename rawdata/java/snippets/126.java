public static Pair<INDArray, INDArray> mergeLabels(@NonNull INDArray[][] labelsToMerge,
                    INDArray[][] labelMasksToMerge, int inOutIdx) {
        Pair<INDArray[], INDArray[]> p = selectColumnFromMDSData(labelsToMerge, labelMasksToMerge, inOutIdx);
        return mergeLabels(p.getFirst(), p.getSecond());
    }