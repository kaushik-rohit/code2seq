public synchronized INDArray[] output(boolean train, boolean clearInputs, INDArray... input){
        boolean detachedInputs = !clearInputs;  //If !clearInputs, then inputs should be detached (otherwise: will be out of scope)
        try {
            return outputOfLayersDetached(train, FwdPassType.STANDARD, getOutputLayerIndices(), input, null, null, clearInputs, detachedInputs, null);
        } catch (OutOfMemoryError e){
            CrashReportingUtil.writeMemoryCrashDump(this, e);
            throw e;
        }
    }