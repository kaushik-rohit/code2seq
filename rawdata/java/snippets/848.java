@SuppressWarnings({"WeakerAccess", "unchecked"})
    protected @Nullable BeanIntrospection<Object> getBeanIntrospection(@Nonnull Object object) {
        //noinspection ConstantConditions
        if (object == null) {
            return null;
        }
        if (object instanceof Class) {
            return BeanIntrospector.SHARED.findIntrospection((Class<Object>) object).orElse(null);
        }
        return BeanIntrospector.SHARED.findIntrospection((Class<Object>) object.getClass()).orElse(null);
    }