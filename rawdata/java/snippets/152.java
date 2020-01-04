@Override
    public int iamax(INDArray arr) {
        if (arr.isSparse()) {
            return Nd4j.getSparseBlasWrapper().level1().iamax(arr);
        }
        if (Nd4j.getExecutioner().getProfilingMode() == OpExecutioner.ProfilingMode.ALL)
            OpProfiler.getInstance().processBlasCall(false, arr);

        if (arr.data().dataType() == DataType.DOUBLE) {
            DefaultOpExecutioner.validateDataType(DataType.DOUBLE, arr);
            return idamax(arr.length(), arr, BlasBufferUtil.getBlasStride(arr));
        } else {
            DefaultOpExecutioner.validateDataType(DataType.FLOAT, arr);
            return isamax(arr.length(), arr, BlasBufferUtil.getBlasStride(arr));
        }
    }