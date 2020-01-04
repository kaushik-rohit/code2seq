protected void checkBufferCoherence(){
        if (values.length() < length){
            throw new IllegalStateException("nnz is larger than capacity of buffers");
        }

        if (values.length() * rank() != indices.length()){
            throw new IllegalArgumentException("Sizes of values, indices and shape are incoherent.");
        }
    }