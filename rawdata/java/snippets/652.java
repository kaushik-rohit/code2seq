protected @Nonnull <T> Collection<T> getBeansOfType(@Nullable BeanResolutionContext resolutionContext, @Nonnull Class<T> beanType) {
        return getBeansOfTypeInternal(resolutionContext, beanType, null);
    }