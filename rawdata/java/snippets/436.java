public void addConfigurations(Configuration... configurations) {
		Assert.notNull(configurations, "Configurations must not be null");
		this.configurations.addAll(Arrays.asList(configurations));
	}