private static <T> GenericIndexed<T> createGenericIndexedVersionTwo(
      ByteBuffer byteBuffer,
      ObjectStrategy<T> strategy,
      SmooshedFileMapper fileMapper
  )
  {
    if (fileMapper == null) {
      throw new IAE("SmooshedFileMapper can not be null for version 2.");
    }
    boolean allowReverseLookup = byteBuffer.get() == REVERSE_LOOKUP_ALLOWED;
    int logBaseTwoOfElementsPerValueFile = byteBuffer.getInt();
    int numElements = byteBuffer.getInt();

    try {
      String columnName = SERIALIZER_UTILS.readString(byteBuffer);
      int elementsPerValueFile = 1 << logBaseTwoOfElementsPerValueFile;
      int numberOfFilesRequired = getNumberOfFilesRequired(elementsPerValueFile, numElements);
      ByteBuffer[] valueBuffersToUse = new ByteBuffer[numberOfFilesRequired];
      for (int i = 0; i < numberOfFilesRequired; i++) {
        // SmooshedFileMapper.mapFile() contract guarantees that the valueBuffer's limit equals to capacity.
        ByteBuffer valueBuffer = fileMapper.mapFile(GenericIndexedWriter.generateValueFileName(columnName, i));
        valueBuffersToUse[i] = valueBuffer.asReadOnlyBuffer();
      }
      ByteBuffer headerBuffer = fileMapper.mapFile(GenericIndexedWriter.generateHeaderFileName(columnName));
      return new GenericIndexed<>(
          valueBuffersToUse,
          headerBuffer,
          strategy,
          allowReverseLookup,
          logBaseTwoOfElementsPerValueFile,
          numElements
      );
    }
    catch (IOException e) {
      throw new RuntimeException("File mapping failed.", e);
    }
  }