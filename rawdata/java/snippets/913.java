public static DateTime parseTimeToday(String timeString) {
		timeString = StrUtil.format("{} {}", today(), timeString);
		return parse(timeString, DatePattern.NORM_DATETIME_FORMAT);
	}