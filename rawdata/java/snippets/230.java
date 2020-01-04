public void addBiasParam(@NonNull String paramKey, @NonNull long... paramShape) {
        Preconditions.checkArgument(paramShape.length > 0, "Provided mia- parameter shape is"
                        + " invalid: length 0 provided for shape. Parameter: " + paramKey);
        biasParams.put(paramKey, paramShape);
        paramsList = null;
        weightParamsList = null;
        biasParamsList = null;
    }