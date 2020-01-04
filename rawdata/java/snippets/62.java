public List<INDArray> feedForwardToLayer(int layerNum, INDArray input) {
        try{
            return ffToLayerActivationsDetached(false, FwdPassType.STANDARD, false, layerNum, input, mask, null, true);
        } catch (OutOfMemoryError e) {
            CrashReportingUtil.writeMemoryCrashDump(this, e);
            throw e;
        }
    }