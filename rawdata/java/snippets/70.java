public static Binder get(Environment environment) {
		return new Binder(ConfigurationPropertySources.get(environment),
				new PropertySourcesPlaceholdersResolver(environment));
	}