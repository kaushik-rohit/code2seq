public static INDArray gte(INDArray x, INDArray y, INDArray z, int... dimensions) {
        if(dimensions == null || dimensions.length == 0) {
            validateShapesNoDimCase(x,y,z);
            return Nd4j.getExecutioner().exec(new OldGreaterThanOrEqual(x,y,z));
        }

        return Nd4j.getExecutioner().exec(new BroadcastGreaterThanOrEqual(x,y,z,dimensions));
    }