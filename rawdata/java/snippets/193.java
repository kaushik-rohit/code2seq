public static Method getMethodByName(Class<?> clazz, String methodName) throws SecurityException {
		return getMethodByName(clazz, false, methodName);
	}