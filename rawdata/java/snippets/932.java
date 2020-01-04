static ConfigurationPropertyName of(CharSequence name, boolean returnNullIfInvalid) {
		Elements elements = elementsOf(name, returnNullIfInvalid);
		return (elements != null) ? new ConfigurationPropertyName(elements) : null;
	}