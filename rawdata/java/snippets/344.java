@Override public boolean process(Set<? extends TypeElement> annotations, RoundEnvironment roundEnv) {
		if (errorToShow != null) {
			if (errorToShow != null) {
				Set<? extends Element> rootElements = roundEnv.getRootElements();
				if (!rootElements.isEmpty()) {
					processingEnv.getMessager().printMessage(Kind.WARNING, errorToShow, rootElements.iterator().next());
					errorToShow = null;
				}
			}
		}
		return false;
	}