public void setContextLifecycleListeners(
			Collection<? extends LifecycleListener> contextLifecycleListeners) {
		Assert.notNull(contextLifecycleListeners,
				"ContextLifecycleListeners must not be null");
		this.contextLifecycleListeners = new ArrayList<>(contextLifecycleListeners);
	}