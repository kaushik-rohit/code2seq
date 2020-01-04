public static Color randomColor(Random random) {
		if (null == random) {
			random = RandomUtil.getRandom();
		}
		return new Color(random.nextInt(255), random.nextInt(255), random.nextInt(255));
	}