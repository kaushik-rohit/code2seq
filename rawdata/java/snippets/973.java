public static int getSameModeTopLeftPadding(int outSize, int inSize, int kernel, int strides, int dilation) {
        int eKernel = effectiveKernelSize(kernel, dilation);
        //Note that padBottom is 1 bigger than this if bracketed term is not divisible by 2
        int outPad = ((outSize - 1) * strides + eKernel - inSize) / 2;
        Preconditions.checkState(outPad >= 0, "Invalid padding values calculated: %s - " +
                        "layer configuration is invalid? Input size %s, output size %s, kernel %s, " +
                        "strides %s, dilation %s", outPad, inSize, outSize, kernel, strides, dilation);
        return outPad;
    }