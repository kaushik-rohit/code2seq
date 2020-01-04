public static <T> int indexOf(T[] array, Object value) {
		if (null != array) {
			for (int i = 0; i < array.length; i++) {
				if (ObjectUtil.equal(value, array[i])) {
					return i;
				}
			}
		}
		return INDEX_NOT_FOUND;
	}