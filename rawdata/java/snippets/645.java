public static Integer getInteger(String propertyName, String envName, Integer defaultValue) {
		checkEnvName(envName);
		Integer propertyValue = NumberUtil.toIntObject(System.getProperty(propertyName), null);
		if (propertyValue != null) {
			return propertyValue;
		} else {
			propertyValue = NumberUtil.toIntObject(System.getenv(envName), null);
			return propertyValue != null ? propertyValue : defaultValue;
		}
	}