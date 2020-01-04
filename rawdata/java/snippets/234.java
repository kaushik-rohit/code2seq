private void readObject(ObjectInputStream in) throws IOException, ClassNotFoundException {
		in.defaultReadObject();

		// kryoRegistrations may be null if this value serializer is deserialized from an old version
		if (kryoRegistrations == null) {
			this.kryoRegistrations = asKryoRegistrations(type);
		}
	}