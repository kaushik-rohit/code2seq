public INDArray asMatrix(BufferedImage image, boolean flipChannels) throws IOException {
        if (converter == null) {
            converter = new OpenCVFrameConverter.ToMat();
        }
        return asMatrix(converter.convert(converter2.getFrame(image, 1.0, flipChannels)));
    }