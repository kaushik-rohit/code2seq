public IEvaluation[] doEvaluation(JavaRDD<String> data, int evalNumWorkers, int evalBatchSize, DataSetLoader loader, IEvaluation... emptyEvaluations) {
        return doEvaluation(data, evalNumWorkers, evalBatchSize, loader, null, emptyEvaluations);
    }