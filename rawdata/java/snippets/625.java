public static boolean isNullOrWhitespaceOnly(String str) {
		if (str == null || str.length() == 0) {
			return true;
		}

		final int len = str.length();
		for (int i = 0; i < len; i++) {
			if (!Character.isWhitespace(str.charAt(i))) {
				return false;
			}
		}
		return true;
	}