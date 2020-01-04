public static List<String> findAll(String regex, CharSequence content, int group) {
		return findAll(regex, content, group, new ArrayList<String>());
	}