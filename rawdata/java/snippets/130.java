@SuppressWarnings("unchecked")
	public static <T> TypeInformation<T> convertToTypeInfo(String avroSchemaString) {
		Preconditions.checkNotNull(avroSchemaString, "Avro schema must not be null.");
		final Schema schema;
		try {
			schema = new Schema.Parser().parse(avroSchemaString);
		} catch (SchemaParseException e) {
			throw new IllegalArgumentException("Could not parse Avro schema string.", e);
		}
		return (TypeInformation<T>) convertToTypeInfo(schema);
	}