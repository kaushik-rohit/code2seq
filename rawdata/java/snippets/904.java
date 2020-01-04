public static <T> T toBean(String jsonString, Type beanType, boolean ignoreError) {
		return toBean(parseObj(jsonString), beanType, ignoreError);
	}