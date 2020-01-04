public static String formatBetween(long betweenMs, BetweenFormater.Level level) {
		return new BetweenFormater(betweenMs, level).format();
	}