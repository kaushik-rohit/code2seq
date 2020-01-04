static <IN, OUT> FlatSelectBuilder<IN, OUT> fromFlatSelect(final PatternFlatSelectFunction<IN, OUT> function) {
		return new FlatSelectBuilder<>(function);
	}