private DeltaIteration<ST, WT> setResources(ResourceSpec minResources, ResourceSpec preferredResources) {
		Preconditions.checkNotNull(minResources, "The min resources must be not null.");
		Preconditions.checkNotNull(preferredResources, "The preferred resources must be not null.");
		Preconditions.checkArgument(minResources.isValid() && preferredResources.isValid() && minResources.lessThanOrEqual(preferredResources),
				"The values in resources must be not less than 0 and the preferred resources must be greater than the min resources.");

		this.minResources = minResources;
		this.preferredResources = preferredResources;

		return this;
	}