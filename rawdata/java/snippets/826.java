void writeSpan(Span span, int sizeOfSpan, Buffer result) {
    result.writeByte(SPAN.key);
    result.writeVarint(sizeOfSpan); // length prefix
    SPAN.writeValue(result, span);
  }