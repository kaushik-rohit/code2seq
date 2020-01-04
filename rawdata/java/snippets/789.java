@SuppressWarnings("unchecked")
    static void registerAnnotationType(AnnotationClassValue<?> annotationClassValue) {
        final String name = annotationClassValue.getName();
        if (!ANNOTATION_TYPES.containsKey(name)) {
            annotationClassValue.getType().ifPresent((Consumer<Class<?>>) aClass -> {
                if (Annotation.class.isAssignableFrom(aClass)) {
                    ANNOTATION_TYPES.put(name, (Class<? extends Annotation>) aClass);
                }
            });
        }
    }