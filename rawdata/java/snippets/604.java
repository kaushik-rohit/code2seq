private void addRootFileSeed(URI baseUri, String fileName) {
		String seed = buildUri(baseUri.getScheme(), baseUri.getRawHost(), baseUri.getPort(), "/" + fileName);
		try {
			this.seedList.add(new URI(seed, true));
		} catch (Exception e) {
			log.warn("Error while creating [" + fileName + "] seed: " + seed, e);
		}
	}