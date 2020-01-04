@Override
    public Pair<DataBuffer, long[]> createShapeInformation(long[] shape, DataType dataType) {
        char order = Nd4j.order();

        return createShapeInformation(shape, order, dataType);
    }