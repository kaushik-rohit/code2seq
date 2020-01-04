public String toDateStr() {
		if (null != this.timeZone) {
			final SimpleDateFormat simpleDateFormat = new SimpleDateFormat(DatePattern.NORM_DATE_PATTERN);
			simpleDateFormat.setTimeZone(this.timeZone);
			return toString(simpleDateFormat);
		}
		return toString(DatePattern.NORM_DATE_FORMAT);
	}