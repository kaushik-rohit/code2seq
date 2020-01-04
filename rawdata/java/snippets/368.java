public final File getValidDirectory() {
		File file = this.directory;
		file = (file != null) ? file : getWarFileDocumentRoot();
		file = (file != null) ? file : getExplodedWarFileDocumentRoot();
		file = (file != null) ? file : getCommonDocumentRoot();
		if (file == null && this.logger.isDebugEnabled()) {
			logNoDocumentRoots();
		}
		else if (this.logger.isDebugEnabled()) {
			this.logger.debug("Document root: " + file);
		}
		return file;
	}