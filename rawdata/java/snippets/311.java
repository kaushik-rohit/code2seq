public OverWindow as(Expression alias) {
		return new OverWindow(
			alias,
			partitionBy,
			orderBy,
			new CallExpression(BuiltInFunctionDefinitions.UNBOUNDED_RANGE, Collections.emptyList()),
			Optional.empty());
	}