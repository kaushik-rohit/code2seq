public static void loadJar(URLClassLoader loader, File jarFile) throws UtilException {
		try {
			final Method method = ClassUtil.getDeclaredMethod(URLClassLoader.class, "addURL", URL.class);
			if (null != method) {
				method.setAccessible(true);
				final List<File> jars = loopJar(jarFile);
				for (File jar : jars) {
					ReflectUtil.invoke(loader, method, new Object[] { jar.toURI().toURL() });
				}
			}
		} catch (IOException e) {
			throw new UtilException(e);
		}
	}