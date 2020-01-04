public <T0, T1, T2, T3, T4> SingleOutputStreamOperator<Tuple5<T0, T1, T2, T3, T4>> projectTuple5() {
		TypeInformation<?>[] fTypes = extractFieldTypes(fieldIndexes, dataStream.getType());
		TupleTypeInfo<Tuple5<T0, T1, T2, T3, T4>> tType = new TupleTypeInfo<Tuple5<T0, T1, T2, T3, T4>>(fTypes);

		return dataStream.transform("Projection", tType, new StreamProject<IN, Tuple5<T0, T1, T2, T3, T4>>(fieldIndexes, tType.createSerializer(dataStream.getExecutionConfig())));
	}