public Entity addFieldNames(String... fieldNames) {
		if (ArrayUtil.isNotEmpty(fieldNames)) {
			if (null == this.fieldNames) {
				return setFieldNames(fieldNames);
			} else {
				for (String fieldName : fieldNames) {
					this.fieldNames.add(fieldName);
				}
			}
		}
		return this;
	}