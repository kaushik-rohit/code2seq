@Nonnull
	public final TypeSerializer<T> previousSchemaSerializer() {
		if (cachedRestoredSerializer != null) {
			return cachedRestoredSerializer;
		}

		if (previousSerializerSnapshot == null) {
			throw new UnsupportedOperationException(
				"This provider does not contain the state's previous serializer's snapshot. Cannot provider a serializer for previous schema.");
		}

		this.cachedRestoredSerializer = previousSerializerSnapshot.restoreSerializer();
		return cachedRestoredSerializer;
	}