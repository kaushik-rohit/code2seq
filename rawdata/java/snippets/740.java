@SuppressWarnings({ "unchecked", "rawtypes" })
	public ReduceOperator<T> minBy(int... fields)  {
		if (!getType().isTupleType()) {
			throw new InvalidProgramException("DataSet#minBy(int...) only works on Tuple types.");
		}

		return new ReduceOperator<>(this, new SelectByMinFunction(
			(TupleTypeInfo) getType(), fields), Utils.getCallLocationName());
	}