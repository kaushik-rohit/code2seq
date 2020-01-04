@SafeVarargs
	public static <T> List<T> list(boolean isLinked, T... values) {
		if (ArrayUtil.isEmpty(values)) {
			return list(isLinked);
		}
		List<T> arrayList = isLinked ? new LinkedList<T>() : new ArrayList<T>(values.length);
		for (T t : values) {
			arrayList.add(t);
		}
		return arrayList;
	}