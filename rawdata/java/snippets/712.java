public void setCustomEndpointInitializer(EndpointInitializer initializer) {
		Objects.requireNonNull(initializer, "Initializer has to be set");
		ClosureCleaner.ensureSerializable(initializer);
		this.initializer = initializer;
	}