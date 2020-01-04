public void setSkipURLString(String skipURL) {
		this.skipURL = skipURL;
		getConfig().setProperty(SPIDER_SKIP_URL, this.skipURL);
		parseSkipURL(this.skipURL);
	}