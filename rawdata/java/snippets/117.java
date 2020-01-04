public static ValidationResult deleteInvalidMultiDataSets(JavaSparkContext sc, String path, List<int[]> featuresShape,
                                                       List<int[]> labelsShape) {
        return validateMultiDataSets(sc, path, true, true, (featuresShape == null ? -1 : featuresShape.size()),
                (labelsShape == null ? -1 : labelsShape.size()), featuresShape, labelsShape);
    }