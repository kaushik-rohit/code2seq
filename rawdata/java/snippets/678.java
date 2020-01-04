public JSONArray getJSONArray(K key) {
		final Object object = this.getObj(key);
		if(null == object) {
			return null;
		}
		
		if(object instanceof JSONArray) {
			return (JSONArray) object;
		}
		return new JSONArray(object);
	}