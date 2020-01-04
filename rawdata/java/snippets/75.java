private void validateClusterSpecification(ClusterSpecification clusterSpecification) throws FlinkException {
		try {
			final long taskManagerMemorySize = clusterSpecification.getTaskManagerMemoryMB();
			// We do the validation by calling the calculation methods here
			// Internally these methods will check whether the cluster can be started with the provided
			// ClusterSpecification and the configured memory requirements
			final long cutoff = ContaineredTaskManagerParameters.calculateCutoffMB(flinkConfiguration, taskManagerMemorySize);
			TaskManagerServices.calculateHeapSizeMB(taskManagerMemorySize - cutoff, flinkConfiguration);
		} catch (IllegalArgumentException iae) {
			throw new FlinkException("Cannot fulfill the minimum memory requirements with the provided " +
				"cluster specification. Please increase the memory of the cluster.", iae);
		}
	}