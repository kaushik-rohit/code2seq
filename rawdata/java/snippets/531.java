public Setting set(String group, String key, String value) {
		this.put(group, key, value);
		return this;
	}