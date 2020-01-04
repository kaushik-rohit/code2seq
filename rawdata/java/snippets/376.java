public static int djbHash(String str) {
		int hash = 5381;

		for (int i = 0; i < str.length(); i++) {
			hash = ((hash << 5) + hash) + str.charAt(i);
		}

		return hash & 0x7FFFFFFF;
	}