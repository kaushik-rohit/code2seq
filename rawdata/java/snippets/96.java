public static MessageValidity validMessage(NDArrayMessage message) {
        if (message.getDimensions() == null || message.getArr() == null)
            return MessageValidity.NULL_VALUE;

        if (message.getIndex() != -1 && message.getDimensions().length == 1 && message.getDimensions()[0] != -1)
            return MessageValidity.INCONSISTENT_DIMENSIONS;
        return MessageValidity.VALID;
    }