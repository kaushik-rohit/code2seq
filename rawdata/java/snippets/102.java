public Optional<String> getFieldName(int fieldIndex) {
		if (fieldIndex < 0 || fieldIndex >= fieldNames.length) {
			return Optional.empty();
		}
		return Optional.of(fieldNames[fieldIndex]);
	}