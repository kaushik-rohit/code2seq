@PublicEvolving
	@Deprecated
	public <ACC, R> SingleOutputStreamOperator<R> fold(ACC initialValue,
			FoldFunction<T, ACC> foldFunction,
			AllWindowFunction<ACC, R, W> function,
			TypeInformation<ACC> foldAccumulatorType,
			TypeInformation<R> resultType) {
		if (foldFunction instanceof RichFunction) {
			throw new UnsupportedOperationException("FoldFunction of fold can not be a RichFunction.");
		}
		if (windowAssigner instanceof MergingWindowAssigner) {
			throw new UnsupportedOperationException("Fold cannot be used with a merging WindowAssigner.");
		}

		//clean the closures
		function = input.getExecutionEnvironment().clean(function);
		foldFunction = input.getExecutionEnvironment().clean(foldFunction);

		String callLocation = Utils.getCallLocationName();
		String udfName = "AllWindowedStream." + callLocation;

		String opName;
		KeySelector<T, Byte> keySel = input.getKeySelector();

		OneInputStreamOperator<T, R> operator;

		if (evictor != null) {
			@SuppressWarnings({"unchecked", "rawtypes"})
			TypeSerializer<StreamRecord<T>> streamRecordSerializer =
				(TypeSerializer<StreamRecord<T>>) new StreamElementSerializer(input.getType().createSerializer(getExecutionEnvironment().getConfig()));

			ListStateDescriptor<StreamRecord<T>> stateDesc =
				new ListStateDescriptor<>("window-contents", streamRecordSerializer);

			opName = "TriggerWindow(" + windowAssigner + ", " + stateDesc + ", " + trigger + ", " + evictor + ", " + udfName + ")";

			operator =
				new EvictingWindowOperator<>(windowAssigner,
					windowAssigner.getWindowSerializer(getExecutionEnvironment().getConfig()),
					keySel,
					input.getKeyType().createSerializer(getExecutionEnvironment().getConfig()),
					stateDesc,
					new InternalIterableAllWindowFunction<>(new FoldApplyAllWindowFunction<>(initialValue, foldFunction, function, foldAccumulatorType)),
					trigger,
					evictor,
					allowedLateness,
					lateDataOutputTag);

		} else {
			FoldingStateDescriptor<T, ACC> stateDesc = new FoldingStateDescriptor<>("window-contents",
				initialValue, foldFunction, foldAccumulatorType.createSerializer(getExecutionEnvironment().getConfig()));

			opName = "TriggerWindow(" + windowAssigner + ", " + stateDesc + ", " + trigger + ", " + udfName + ")";

			operator =
				new WindowOperator<>(windowAssigner,
					windowAssigner.getWindowSerializer(getExecutionEnvironment().getConfig()),
					keySel,
					input.getKeyType().createSerializer(getExecutionEnvironment().getConfig()),
					stateDesc,
					new InternalSingleValueAllWindowFunction<>(function),
					trigger,
					allowedLateness,
					lateDataOutputTag);
		}

		return input.transform(opName, resultType, operator).forceNonParallel();
	}