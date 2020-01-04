public double[] getWordVector(String word) {
        INDArray r = getWordVectorMatrix(word);
        if (r == null)
            return null;
        return r.dup().data().asDouble();
    }