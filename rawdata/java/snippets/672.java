public void handleAnnotation(JCCompilationUnit unit, JavacNode node, JCAnnotation annotation, long priority) {
		TypeResolver resolver = new TypeResolver(node.getImportList());
		String rawType = annotation.annotationType.toString();
		String fqn = resolver.typeRefToFullyQualifiedName(node, typeLibrary, rawType);
		if (fqn == null) return;
		List<AnnotationHandlerContainer<?>> containers = annotationHandlers.get(fqn);
		if (containers == null) return;
		
		for (AnnotationHandlerContainer<?> container : containers) {
			try {
				if (container.getPriority() == priority) {
					if (checkAndSetHandled(annotation)) {
						container.handle(node);
					} else {
						if (container.isEvenIfAlreadyHandled()) container.handle(node);
					}
				}
			} catch (AnnotationValueDecodeFail fail) {
				fail.owner.setError(fail.getMessage(), fail.idx);
			} catch (Throwable t) {
				String sourceName = "(unknown).java";
				if (unit != null && unit.sourcefile != null) sourceName = unit.sourcefile.getName();
				javacError(String.format("Lombok annotation handler %s failed on " + sourceName, container.handler.getClass()), t);
			}
		}
	}