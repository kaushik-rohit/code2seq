void addColumn(String family, String qualifier, Class<?> clazz) {
		Preconditions.checkNotNull(family, "family name");
		Preconditions.checkNotNull(qualifier, "qualifier name");
		Preconditions.checkNotNull(clazz, "class type");
		Map<String, TypeInformation<?>> qualifierMap = this.familyMap.get(family);

		if (!HBaseRowInputFormat.isSupportedType(clazz)) {
			// throw exception
			throw new IllegalArgumentException("Unsupported class type found " + clazz + ". " +
				"Better to use byte[].class and deserialize using user defined scalar functions");
		}

		if (qualifierMap == null) {
			qualifierMap = new LinkedHashMap<>();
		}
		qualifierMap.put(qualifier, TypeExtractor.getForClass(clazz));
		familyMap.put(family, qualifierMap);
	}