private boolean readModule(int row, int column, int numRows, int numColumns) {
    // Adjust the row and column indices based on boundary wrapping
    if (row < 0) {
      row += numRows;
      column += 4 - ((numRows + 4) & 0x07);
    }
    if (column < 0) {
      column += numColumns;
      row += 4 - ((numColumns + 4) & 0x07);
    }
    readMappingMatrix.set(column, row);
    return mappingBitMatrix.get(column, row);
  }