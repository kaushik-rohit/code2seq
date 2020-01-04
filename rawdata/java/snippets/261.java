public <T> T output(@NonNull ModelAdapter<T> adapter, INDArray... inputs) {
        return output(adapter, inputs, null);
    }