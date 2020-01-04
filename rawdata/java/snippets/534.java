public static <T> TypeInformation<T> POJO(Class<T> pojoClass, Map<String, TypeInformation<?>> fields) {
		final List<PojoField> pojoFields = new ArrayList<>(fields.size());
		for (Map.Entry<String, TypeInformation<?>> field : fields.entrySet()) {
			final Field f = TypeExtractor.getDeclaredField(pojoClass, field.getKey());
			if (f == null) {
				throw new InvalidTypesException("Field '" + field.getKey() + "'could not be accessed.");
			}
			pojoFields.add(new PojoField(f, field.getValue()));
		}

		return new PojoTypeInfo<>(pojoClass, pojoFields);
	}