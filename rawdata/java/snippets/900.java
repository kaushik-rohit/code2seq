public static void isAssignable(Class<?> superType, Class<?> subType, String errorMsgTemplate, Object... params) throws IllegalArgumentException {
		notNull(superType, "Type to check against must not be null");
		if (subType == null || !superType.isAssignableFrom(subType)) {
			throw new IllegalArgumentException(StrUtil.format(errorMsgTemplate, params));
		}
	}