protected final ServletContextInitializer[] mergeInitializers(
			ServletContextInitializer... initializers) {
		List<ServletContextInitializer> mergedInitializers = new ArrayList<>();
		mergedInitializers.add((servletContext) -> this.initParameters
				.forEach(servletContext::setInitParameter));
		mergedInitializers.add(new SessionConfiguringInitializer(this.session));
		mergedInitializers.addAll(Arrays.asList(initializers));
		mergedInitializers.addAll(this.initializers);
		return mergedInitializers.toArray(new ServletContextInitializer[0]);
	}