public SpringApplicationBuilder child(Class<?>... sources) {
		SpringApplicationBuilder child = new SpringApplicationBuilder();
		child.sources(sources);

		// Copy environment stuff from parent to child
		child.properties(this.defaultProperties).environment(this.environment)
				.additionalProfiles(this.additionalProfiles);
		child.parent = this;

		// It's not possible if embedded web server are enabled to support web contexts as
		// parents because the servlets cannot be initialized at the right point in
		// lifecycle.
		web(WebApplicationType.NONE);

		// Probably not interested in multiple banners
		bannerMode(Banner.Mode.OFF);

		// Make sure sources get copied over
		this.application.addPrimarySources(this.sources);

		return child;
	}