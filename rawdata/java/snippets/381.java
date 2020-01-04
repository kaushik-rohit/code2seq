public static ScopeFormats fromConfig(Configuration config) {
		String jmFormat = config.getString(MetricOptions.SCOPE_NAMING_JM);
		String jmJobFormat = config.getString(MetricOptions.SCOPE_NAMING_JM_JOB);
		String tmFormat = config.getString(MetricOptions.SCOPE_NAMING_TM);
		String tmJobFormat = config.getString(MetricOptions.SCOPE_NAMING_TM_JOB);
		String taskFormat = config.getString(MetricOptions.SCOPE_NAMING_TASK);
		String operatorFormat = config.getString(MetricOptions.SCOPE_NAMING_OPERATOR);

		return new ScopeFormats(jmFormat, jmJobFormat, tmFormat, tmJobFormat, taskFormat, operatorFormat);
	}