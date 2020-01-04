@Override
	public final void register(Class<?>... annotatedClasses) {
		Assert.notEmpty(annotatedClasses,
				"At least one annotated class must be specified");
		this.annotatedClasses.addAll(Arrays.asList(annotatedClasses));
	}