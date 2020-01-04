public static String randomStringFixLength(Random random, int length) {
		return RandomStringUtils.random(length, 0, 0, true, true, null, random);
	}