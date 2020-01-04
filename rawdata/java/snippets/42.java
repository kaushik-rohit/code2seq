private static Date parse(String dateStr, DateFormat dateFormat) {
		try {
			return dateFormat.parse(dateStr);
		} catch (Exception e) {
			String pattern;
			if (dateFormat instanceof SimpleDateFormat) {
				pattern = ((SimpleDateFormat) dateFormat).toPattern();
			} else {
				pattern = dateFormat.toString();
			}
			throw new DateException(StrUtil.format("Parse [{}] with format [{}] error!", dateStr, pattern), e);
		}
	}