public boolean isApplicable(Class<? extends Job> jobType) {
        Type parameterization = Types.getBaseClass(clazz, JobProperty.class);
        if (parameterization instanceof ParameterizedType) {
            ParameterizedType pt = (ParameterizedType) parameterization;
            Class applicable = Types.erasure(Types.getTypeArgument(pt, 0));
            return applicable.isAssignableFrom(jobType);
        } else {
            throw new AssertionError(clazz+" doesn't properly parameterize JobProperty. The isApplicable() method must be overridden.");
        }
    }