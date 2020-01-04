public void enable() throws IOException {
        if (!disableFile.exists()) {
            LOGGER.log(Level.FINEST, "Plugin {0} has been already enabled. Skipping the enable() operation", getShortName());
            return;
        }
        if(!disableFile.delete())
            throw new IOException("Failed to delete "+disableFile);
    }