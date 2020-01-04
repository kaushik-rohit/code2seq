public static List<String> splitIgnoreCase(String str, String separator, int limit, boolean isTrim, boolean ignoreEmpty){
		return split(str, separator, limit, isTrim, ignoreEmpty, true);
	}