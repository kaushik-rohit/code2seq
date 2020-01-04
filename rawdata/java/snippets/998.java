public Pattern<T, T> notFollowedBy(final String name) {
		if (quantifier.hasProperty(Quantifier.QuantifierProperty.OPTIONAL)) {
			throw new UnsupportedOperationException(
					"Specifying a pattern with an optional path to NOT condition is not supported yet. " +
					"You can simulate such pattern with two independent patterns, one with and the other without " +
					"the optional part.");
		}
		return new Pattern<>(name, this, ConsumingStrategy.NOT_FOLLOW, afterMatchSkipStrategy);
	}