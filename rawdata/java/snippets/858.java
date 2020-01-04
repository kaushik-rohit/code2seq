@Override
	public void close() {
		IOUtils.closeQuietly(defaultColumnFamilyHandle);
		IOUtils.closeQuietly(nativeMetricMonitor);
		IOUtils.closeQuietly(db);
		// Making sure the already created column family options will be closed
		columnFamilyDescriptors.forEach((cfd) -> IOUtils.closeQuietly(cfd.getOptions()));
	}