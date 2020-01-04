public INDArray hash(INDArray data) {
        if (data.shape()[1] != inDimension){
            throw new ND4JIllegalStateException(
                    String.format("Invalid shape: Requested INDArray shape %s, this table expects dimension %d",
                            Arrays.toString(data.shape()), inDimension));
        }
        INDArray projected = data.mmul(randomProjection);
        INDArray res = Nd4j.getExecutioner().exec(new Sign(projected));
        return res;
    }