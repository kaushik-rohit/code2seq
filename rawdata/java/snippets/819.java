public boolean isAnnotated(ExecutableElement method) {
        List<? extends AnnotationMirror> annotationMirrors = method.getAnnotationMirrors();
        for (AnnotationMirror annotationMirror : annotationMirrors) {
            String typeName = annotationMirror.getAnnotationType().toString();
            if (!AnnotationUtil.INTERNAL_ANNOTATION_NAMES.contains(typeName)) {
                return true;
            }
        }
        return false;
    }