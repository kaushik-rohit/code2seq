@Override
    public InputType getOutputType(InputType... inputType) throws InvalidKerasConfigurationException {
        if (inputType.length > 1)
            throw new InvalidKerasConfigurationException(
                            "Keras ZeroPadding layer accepts only one input (received " + inputType.length + ")");
        return this.getZeroPadding2DLayer().getOutputType(-1, inputType[0]);
    }