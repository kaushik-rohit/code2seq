public static RelDataType createSqlType(final RelDataTypeFactory typeFactory, final SqlTypeName typeName)
  {
    return createSqlTypeWithNullability(typeFactory, typeName, false);
  }