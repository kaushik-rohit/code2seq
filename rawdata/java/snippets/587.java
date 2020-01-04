public static String findMainClass(JarFile jarFile, String classesLocation)
			throws IOException {
		return doWithMainClasses(jarFile, classesLocation, MainClass::getName);
	}