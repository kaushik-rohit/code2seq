public static Object copy(Object src, Object dest, int length) {
		System.arraycopy(src, 0, dest, 0, length);
		return dest;
	}