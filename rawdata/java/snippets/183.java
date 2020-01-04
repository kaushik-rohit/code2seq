@Override
    public double similarity(String label1, String label2) {
        if (label1 == null || label2 == null) {
            log.debug("LABELS: " + label1 + ": " + (label1 == null ? "null" : "exists") + ";" + label2 + " vec2:"
                            + (label2 == null ? "null" : "exists"));
            return Double.NaN;
        }

        INDArray vec1 = getWordVectorMatrix(label1).dup();
        INDArray vec2 = getWordVectorMatrix(label2).dup();

        if (vec1 == null || vec2 == null) {
            log.debug(label1 + ": " + (vec1 == null ? "null" : "exists") + ";" + label2 + " vec2:"
                            + (vec2 == null ? "null" : "exists"));
            return Double.NaN;
        }

        if (label1.equals(label2))
            return 1.0;

        vec1 = Transforms.unitVec(vec1);
        vec2 = Transforms.unitVec(vec2);

        return Transforms.cosineSim(vec1, vec2);
    }