public HttpRequest form(Map<String, Object> formMap) {
		if (MapUtil.isNotEmpty(formMap)) {
			for (Map.Entry<String, Object> entry : formMap.entrySet()) {
				form(entry.getKey(), entry.getValue());
			}
		}
		return this;
	}