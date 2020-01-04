@Override
    public void axpy(long n, double alpha, INDArray x, INDArray y) {
        BaseSparseNDArray sparseX = (BaseSparseNDArray) x;
        DataBuffer pointers = sparseX.getVectorCoordinates();
        switch (x.data().dataType()) {
            case DOUBLE:
                DefaultOpExecutioner.validateDataType(DataType.DOUBLE, x);
                DefaultOpExecutioner.validateDataType(DataType.DOUBLE, y);
                daxpyi(n, alpha, x, pointers, y);
                break;
            case FLOAT:
                DefaultOpExecutioner.validateDataType(DataType.FLOAT, x);
                DefaultOpExecutioner.validateDataType(DataType.FLOAT, y);
                saxpyi(n, alpha, x, pointers, y);
                break;
            case HALF:
                DefaultOpExecutioner.validateDataType(DataType.HALF, x);
                DefaultOpExecutioner.validateDataType(DataType.HALF, y);
                haxpyi(n, alpha, x, pointers, y);
                break;
            default:
                throw new UnsupportedOperationException();
        }
    }