public static double score(MultiLayerNetwork model, DataSetIterator testSet, RegressionValue regressionValue) {
        RegressionEvaluation eval = model.evaluateRegression(testSet);
        return getScoreFromRegressionEval(eval, regressionValue);
    }