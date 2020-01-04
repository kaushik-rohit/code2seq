public static BigDecimal parseString(String numberStr, String pattern) throws ParseException {
		DecimalFormat df = null;
		if (StringUtils.isEmpty(pattern)) {
			df = PRETTY_FORMAT.get();
		} else {
			df = (DecimalFormat) DecimalFormat.getInstance();
			df.applyPattern(pattern);
		}

		return new BigDecimal(df.parse(numberStr).doubleValue());
	}