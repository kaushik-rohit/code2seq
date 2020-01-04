public SDVariable huberLoss(String name, @NonNull SDVariable label, @NonNull SDVariable predictions,
                                SDVariable weights, @NonNull LossReduce lossReduce, double delta) {
        validateFloatingPoint("huber loss", "predictions", predictions);
        validateNumerical("huber loss", "labels", label);
        if (weights == null)
            weights = sd.scalar(null, predictions.dataType(), 1.0);
        SDVariable result = f().lossHuber(label, predictions, weights, lossReduce, delta);
        result = updateVariableNameAndReference(result, name);
        result.markAsLoss();
        return result;
    }