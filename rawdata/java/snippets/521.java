public static <T> TypeSerializerSchemaCompatibility<T> compatibleWithReconfiguredSerializer(TypeSerializer<T> reconfiguredSerializer) {
		return new TypeSerializerSchemaCompatibility<>(
			Type.COMPATIBLE_WITH_RECONFIGURED_SERIALIZER,
			Preconditions.checkNotNull(reconfiguredSerializer));
	}