@Override
    public double computeScore(double fullNetRegTerm, boolean training, LayerWorkspaceMgr workspaceMgr) {
        if (input == null)
            throw new IllegalStateException("Cannot calculate score without input and labels " + layerId());
        INDArray preOut = preOutput2d(training, workspaceMgr);

        ILossFunction lossFunction = layerConf().getLossFn();

        double score = lossFunction.computeScore(getLabels2d(workspaceMgr, ArrayType.FF_WORKING_MEM), preOut,
                layerConf().getActivationFn(), maskArray,false);
        if(conf().isMiniBatch())
            score /= getInputMiniBatchSize();

        score += fullNetRegTerm;
        this.score = score;
        return score;
    }