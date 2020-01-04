public static INDArray add(INDArray x, INDArray y, INDArray z, int... dimensions) {
        if(dimensions == null || dimensions.length == 0) {
            validateShapesNoDimCase(x,y,z);
            return Nd4j.getExecutioner().exec(new OldAddOp(x,y,z));
        }

        return Nd4j.getExecutioner().exec(new BroadcastAddOp(x,y,z,dimensions));
    }