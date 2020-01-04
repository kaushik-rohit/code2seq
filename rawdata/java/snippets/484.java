@Override
    public INDArray scalar(float value) {
        if (Nd4j.dataType() == DataType.FLOAT || Nd4j.dataType() == DataType.HALF)
            return create(new float[] {value}, new int[0], new int[0], 0);
        else if (Nd4j.dataType() == DataType.DOUBLE)
            return scalar((double) value);
        else
            return scalar((int) value);
    }