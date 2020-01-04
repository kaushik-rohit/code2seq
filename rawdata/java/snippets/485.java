public void rnnSetPreviousState(String layerName, Map<String, INDArray> state) {
        Layer l = verticesMap.get(layerName).getLayer();
        if(l instanceof org.deeplearning4j.nn.layers.wrapper.BaseWrapperLayer){
            l = ((org.deeplearning4j.nn.layers.wrapper.BaseWrapperLayer)l).getUnderlying();
        }
        if (l == null || !(l instanceof RecurrentLayer)) {
            throw new UnsupportedOperationException(
                    "Layer \"" + layerName + "\" is not a recurrent layer. Cannot set state");
        }
        ((RecurrentLayer) l).rnnSetPreviousState(state);
    }