public static void applyRegistrations(Kryo kryo, Collection<KryoRegistration> resolvedRegistrations) {

		Serializer<?> serializer;
		for (KryoRegistration registration : resolvedRegistrations) {
			serializer = registration.getSerializer(kryo);

			if (serializer != null) {
				kryo.register(registration.getRegisteredClass(), serializer, kryo.getNextRegistrationId());
			} else {
				kryo.register(registration.getRegisteredClass(), kryo.getNextRegistrationId());
			}
		}
	}