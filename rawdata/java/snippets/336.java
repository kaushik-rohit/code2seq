public boolean containsStringConstant(String value) {
		int index = findUtf8(value);
		if (index == NOT_FOUND) return false;
		for (int i = 1; i < maxPoolSize; i++) {
			if (types[i] == STRING && readValue(offsets[i]) == index) return true; 
		}
		return false;
	}