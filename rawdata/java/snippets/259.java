private static Optional<Class> resolveSingleTypeArgument(Type genericType) {
        if (genericType instanceof ParameterizedType) {
            ParameterizedType pt = (ParameterizedType) genericType;
            Type[] actualTypeArguments = pt.getActualTypeArguments();
            if (actualTypeArguments.length == 1) {
                Type actualTypeArgument = actualTypeArguments[0];
                return resolveParameterizedTypeArgument(actualTypeArgument);
            }
        }
        return Optional.empty();
    }