@Override
  protected void reserveInternal(int newCapacity) {
    int oldCapacity = (nulls == 0L) ? 0 : capacity;
    if (isArray() || type instanceof MapType) {
      this.lengthData =
          Platform.reallocateMemory(lengthData, oldCapacity * 4L, newCapacity * 4L);
      this.offsetData =
          Platform.reallocateMemory(offsetData, oldCapacity * 4L, newCapacity * 4L);
    } else if (type instanceof ByteType || type instanceof BooleanType) {
      this.data = Platform.reallocateMemory(data, oldCapacity, newCapacity);
    } else if (type instanceof ShortType) {
      this.data = Platform.reallocateMemory(data, oldCapacity * 2L, newCapacity * 2L);
    } else if (type instanceof IntegerType || type instanceof FloatType ||
        type instanceof DateType || DecimalType.is32BitDecimalType(type)) {
      this.data = Platform.reallocateMemory(data, oldCapacity * 4L, newCapacity * 4L);
    } else if (type instanceof LongType || type instanceof DoubleType ||
        DecimalType.is64BitDecimalType(type) || type instanceof TimestampType) {
      this.data = Platform.reallocateMemory(data, oldCapacity * 8L, newCapacity * 8L);
    } else if (childColumns != null) {
      // Nothing to store.
    } else {
      throw new RuntimeException("Unhandled " + type);
    }
    this.nulls = Platform.reallocateMemory(nulls, oldCapacity, newCapacity);
    Platform.setMemory(nulls + oldCapacity, (byte)0, newCapacity - oldCapacity);
    capacity = newCapacity;
  }