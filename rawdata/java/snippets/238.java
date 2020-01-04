public static INDArrayIndex[] allFor(INDArray arr) {
        INDArrayIndex[] ret = new INDArrayIndex[arr.rank()];
        for (int i = 0; i < ret.length; i++)
            ret[i] = NDArrayIndex.all();

        return ret;
    }