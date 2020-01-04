public int getNumberOfLabelsUsed() {
        if (labels != null && !labels.isEmpty())
            return labels.size();
        else
            return ((Long) (maxCount + 1)).intValue();
    }