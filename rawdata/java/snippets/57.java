public Result decodeWithState(BinaryBitmap image) throws NotFoundException {
    // Make sure to set up the default state so we don't crash
    if (readers == null) {
      setHints(null);
    }
    return decodeInternal(image);
  }