public boolean isNull(int index) {
		Object value = opt(index);
		return value == null || value == JSONObject.NULL;
	}