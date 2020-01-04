public static int sort(
      LongArray array, long numRecords, int startByteIndex, int endByteIndex,
      boolean desc, boolean signed) {
    assert startByteIndex >= 0 : "startByteIndex (" + startByteIndex + ") should >= 0";
    assert endByteIndex <= 7 : "endByteIndex (" + endByteIndex + ") should <= 7";
    assert endByteIndex > startByteIndex;
    assert numRecords * 2 <= array.size();
    long inIndex = 0;
    long outIndex = numRecords;
    if (numRecords > 0) {
      long[][] counts = getCounts(array, numRecords, startByteIndex, endByteIndex);
      for (int i = startByteIndex; i <= endByteIndex; i++) {
        if (counts[i] != null) {
          sortAtByte(
            array, numRecords, counts[i], i, inIndex, outIndex,
            desc, signed && i == endByteIndex);
          long tmp = inIndex;
          inIndex = outIndex;
          outIndex = tmp;
        }
      }
    }
    return Ints.checkedCast(inIndex);
  }