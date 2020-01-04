@InternalApi
  public Row createRowFromProto(com.google.bigtable.v2.Row row) {
    RowBuilder<Row> builder = createRowBuilder();
    builder.startRow(row.getKey());

    for (Family family : row.getFamiliesList()) {
      for (Column column : family.getColumnsList()) {
        for (Cell cell : column.getCellsList()) {
          builder.startCell(
              family.getName(),
              column.getQualifier(),
              cell.getTimestampMicros(),
              cell.getLabelsList(),
              cell.getValue().size());
          builder.cellValue(cell.getValue());
          builder.finishCell();
        }
      }
    }

    return builder.finishRow();
  }