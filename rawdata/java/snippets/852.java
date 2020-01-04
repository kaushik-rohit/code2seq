public TypeInformation<T> getType() {
		if (type instanceof MissingTypeInfo) {
			MissingTypeInfo typeInfo = (MissingTypeInfo) type;
			throw new InvalidTypesException("The return type of function '" + typeInfo.getFunctionName()
					+ "' could not be determined automatically, due to type erasure. "
					+ "You can give type information hints by using the returns(...) method on the result of "
					+ "the transformation call, or by letting your function implement the 'ResultTypeQueryable' "
					+ "interface.", typeInfo.getTypeException());
		}
		typeUsed = true;
		return this.type;
	}