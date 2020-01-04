@Internal
	public static void closeSafetyNetAndGuardedResourcesForThread() {
		SafetyNetCloseableRegistry registry = REGISTRIES.get();
		if (null != registry) {
			REGISTRIES.remove();
			IOUtils.closeQuietly(registry);
		}
	}