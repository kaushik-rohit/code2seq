public static <T> MapPartitionOperator<T, T> sample(
		DataSet <T> input,
		final boolean withReplacement,
		final double fraction,
		final long seed) {

		return input.mapPartition(new SampleWithFraction<T>(withReplacement, fraction, seed));
	}