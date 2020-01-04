public static <L, R> TypeInformation<Either<L, R>> EITHER(TypeInformation<L> leftType, TypeInformation<R> rightType) {
		return new EitherTypeInfo<>(leftType, rightType);
	}