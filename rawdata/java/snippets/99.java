public static Pair<INDArray,int[]> pullLastTimeSteps(INDArray pullFrom, INDArray mask){
        //Then: work out, from the mask array, which time step of activations we want, extract activations
        //Also: record where they came from (so we can do errors later)
        int[] fwdPassTimeSteps;
        INDArray out;
        if (mask == null) {

            // FIXME: int cast
            //No mask array -> extract same (last) column for all
            int lastTS = (int) pullFrom.size(2) - 1;
            out = pullFrom.get(NDArrayIndex.all(), NDArrayIndex.all(), NDArrayIndex.point(lastTS));
            fwdPassTimeSteps = null; //Null -> last time step for all examples
        } else {
            val outShape = new long[] {pullFrom.size(0), pullFrom.size(1)};
            out = Nd4j.create(outShape);

            //Want the index of the last non-zero entry in the mask array
            INDArray lastStepArr = BooleanIndexing.lastIndex(mask, Conditions.epsNotEquals(0.0), 1);
            fwdPassTimeSteps = lastStepArr.data().asInt();

            //Now, get and assign the corresponding subsets of 3d activations:
            for (int i = 0; i < fwdPassTimeSteps.length; i++) {
                //TODO can optimize using reshape + pullRows
                out.putRow(i, pullFrom.get(NDArrayIndex.point(i), NDArrayIndex.all(),
                        NDArrayIndex.point(fwdPassTimeSteps[i])));
            }
        }

        return new Pair<>(out, fwdPassTimeSteps);
    }