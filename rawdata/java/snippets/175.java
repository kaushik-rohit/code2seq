private static <T, K> org.apache.flink.api.common.operators.SingleInputOperator<?, T, ?> translateSelectorFunctionReducer(
		SelectorFunctionKeys<T, ?> rawKeys,
		ReduceFunction<T> function,
		TypeInformation<T> inputType,
		String name,
		Operator<T> input,
		int parallelism,
		CombineHint hint) {
		@SuppressWarnings("unchecked")
		final SelectorFunctionKeys<T, K> keys = (SelectorFunctionKeys<T, K>) rawKeys;

		TypeInformation<Tuple2<K, T>> typeInfoWithKey = KeyFunctions.createTypeWithKey(keys);
		Operator<Tuple2<K, T>> keyedInput = KeyFunctions.appendKeyExtractor(input, keys);

		PlanUnwrappingReduceOperator<T, K> reducer = new PlanUnwrappingReduceOperator<>(function, keys, name, inputType, typeInfoWithKey);
		reducer.setInput(keyedInput);
		reducer.setParallelism(parallelism);
		reducer.setCombineHint(hint);

		return KeyFunctions.appendKeyRemover(reducer, keys);
	}