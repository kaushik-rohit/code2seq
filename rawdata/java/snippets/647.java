public static TypeInformation createInternalTypeInfoFromInternalType(InternalType type) {
		TypeInformation typeInfo = INTERNAL_TYPE_TO_INTERNAL_TYPE_INFO.get(type);
		if (typeInfo != null) {
			return typeInfo;
		}

		if (type instanceof RowType) {
			RowType rowType = (RowType) type;
			return new BaseRowTypeInfo(rowType.getFieldTypes(), rowType.getFieldNames());
		} else if (type instanceof ArrayType) {
			return new BinaryArrayTypeInfo(((ArrayType) type).getElementType());
		} else if (type instanceof MapType) {
			MapType mapType = (MapType) type;
			return new BinaryMapTypeInfo(mapType.getKeyType(), mapType.getValueType());
		} else if (type instanceof DecimalType) {
			DecimalType decimalType = (DecimalType) type;
			return new DecimalTypeInfo(decimalType.precision(), decimalType.scale());
		}  else if (type instanceof GenericType) {
			GenericType<?> genericType = (GenericType<?>) type;
			return new BinaryGenericTypeInfo<>(genericType);
		} else {
			throw new UnsupportedOperationException("Not support yet: " + type);
		}
	}