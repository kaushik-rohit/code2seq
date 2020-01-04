public void addUrls(Collection<URL> urls) {
		Assert.notNull(urls, "Urls must not be null");
		this.urls.addAll(urls);
	}