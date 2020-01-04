public static boolean checkSubtract(INDArray first, INDArray second, double maxRelativeDifference,
                    double minAbsDifference) {
        RealMatrix rmFirst = convertToApacheMatrix(first);
        RealMatrix rmSecond = convertToApacheMatrix(second);

        INDArray result = first.sub(second);
        RealMatrix rmResult = rmFirst.subtract(rmSecond);

        if (!checkShape(rmResult, result))
            return false;
        boolean ok = checkEntries(rmResult, result, maxRelativeDifference, minAbsDifference);
        if (!ok) {
            INDArray onCopies = Shape.toOffsetZeroCopy(first).sub(Shape.toOffsetZeroCopy(second));
            printFailureDetails(first, second, rmResult, result, onCopies, "sub");
        }
        return ok;
    }