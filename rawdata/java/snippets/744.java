public WebServiceTemplateBuilder setDestinationProvider(
			DestinationProvider destinationProvider) {
		Assert.notNull(destinationProvider, "DestinationProvider must not be null");
		return new WebServiceTemplateBuilder(this.detectHttpMessageSender,
				this.interceptors, this.internalCustomizers, this.customizers,
				this.messageSenders, this.marshaller, this.unmarshaller,
				destinationProvider, this.transformerFactoryClass, this.messageFactory);
	}