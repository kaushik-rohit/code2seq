public static String decode(String rot, int offset, boolean isDecodeNumber) {
		final int len = rot.length();
		final char[] chars = new char[len];

		for (int i = 0; i < len; i++) {
			chars[i] = decodeChar(rot.charAt(i), offset, isDecodeNumber);
		}
		return new String(chars);
	}