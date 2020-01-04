public static List<String> splitByRegex(String str, String separatorRegex, int limit, boolean isTrim, boolean ignoreEmpty){
		final Pattern pattern = PatternPool.get(separatorRegex);
		return split(str, pattern, limit, isTrim, ignoreEmpty);
	}