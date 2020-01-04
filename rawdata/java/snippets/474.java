@SuppressWarnings("unused")
    @Internal
    @UsedByGeneratedCode
    protected final Object getBeanForConstructorArgument(BeanResolutionContext resolutionContext, BeanContext context, int argIndex) {
        ConstructorInjectionPoint<T> constructorInjectionPoint = getConstructor();
        Argument<?> argument = constructorInjectionPoint.getArguments()[argIndex];
        if (argument instanceof DefaultArgument) {
            argument = new EnvironmentAwareArgument((DefaultArgument) argument);
            instrumentAnnotationMetadata(context, argument);
        }
        Class argumentType = argument.getType();
        if (argumentType == BeanResolutionContext.class) {
            return resolutionContext;
        } else if (argumentType.isArray()) {
            Collection beansOfType = getBeansOfTypeForConstructorArgument(resolutionContext, context, constructorInjectionPoint, argument);
            return beansOfType.toArray((Object[]) Array.newInstance(argumentType.getComponentType(), beansOfType.size()));
        } else if (Collection.class.isAssignableFrom(argumentType)) {
            Collection beansOfType = getBeansOfTypeForConstructorArgument(resolutionContext, context, constructorInjectionPoint, argument);
            return coerceCollectionToCorrectType(argumentType, beansOfType);
        } else if (Stream.class.isAssignableFrom(argumentType)) {
            return streamOfTypeForConstructorArgument(resolutionContext, context, constructorInjectionPoint, argument);
        } else if (Provider.class.isAssignableFrom(argumentType)) {
            return getBeanProviderForConstructorArgument(resolutionContext, context, constructorInjectionPoint, argument);
        } else if (Optional.class.isAssignableFrom(argumentType)) {
            return findBeanForConstructorArgument(resolutionContext, context, constructorInjectionPoint, argument);
        } else {
            BeanResolutionContext.Path path = resolutionContext.getPath();
            BeanResolutionContext.Segment current = path.peek();
            boolean isNullable = argument.isDeclaredAnnotationPresent(Nullable.class);
            if (isNullable && current != null && current.getArgument().equals(argument)) {
                return null;
            } else {
                path.pushConstructorResolve(this, argument);
                try {
                    Object bean;
                    Qualifier qualifier = resolveQualifier(resolutionContext, argument, isInnerConfiguration(argumentType));
                    //noinspection unchecked
                    bean = ((DefaultBeanContext) context).getBean(resolutionContext, argumentType, qualifier);
                    path.pop();
                    return bean;
                } catch (NoSuchBeanException e) {
                    if (isNullable) {
                        path.pop();
                        return null;
                    }
                    throw new DependencyInjectionException(resolutionContext, argument, e);
                }
            }
        }
    }