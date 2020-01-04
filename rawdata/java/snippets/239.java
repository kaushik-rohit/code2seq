public ConfigurationPropertyName append(String elementValue) {
		if (elementValue == null) {
			return this;
		}
		Elements additionalElements = probablySingleElementOf(elementValue);
		return new ConfigurationPropertyName(this.elements.append(additionalElements));
	}