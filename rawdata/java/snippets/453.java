public T orElseCreate(Class<? extends T> type) {
		Assert.notNull(type, "Type must not be null");
		return (this.value != null) ? this.value : BeanUtils.instantiateClass(type);
	}