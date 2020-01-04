public static RelDataType createSqlTypeWithNullability(
      final RelDataTypeFactory typeFactory,
      final SqlTypeName typeName,
      final boolean nullable
  )
  {
    final RelDataType dataType;

    switch (typeName) {
      case TIMESTAMP:
        // Our timestamps are down to the millisecond (precision = 3).
        dataType = typeFactory.createSqlType(typeName, 3);
        break;
      case CHAR:
      case VARCHAR:
        dataType = typeFactory.createTypeWithCharsetAndCollation(
            typeFactory.createSqlType(typeName),
            Calcites.defaultCharset(),
            SqlCollation.IMPLICIT
        );
        break;
      default:
        dataType = typeFactory.createSqlType(typeName);
    }

    return typeFactory.createTypeWithNullability(dataType, nullable);
  }