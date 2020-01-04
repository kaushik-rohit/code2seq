protected @Nonnull <T> Provider<T> getBeanProvider(@Nullable BeanResolutionContext resolutionContext, @Nonnull Class<T> beanType) {
        return getBeanProvider(resolutionContext, beanType, null);
    }