@Nullable
  private static Object convertPrimitiveField(Group g, int fieldIndex, boolean binaryAsString)
  {
    PrimitiveType pt = (PrimitiveType) g.getType().getFields().get(fieldIndex);
    if (pt.isRepetition(Type.Repetition.REPEATED) && g.getFieldRepetitionCount(fieldIndex) > 1) {
      List<Object> vals = new ArrayList<>();
      for (int i = 0; i < g.getFieldRepetitionCount(fieldIndex); i++) {
        vals.add(convertPrimitiveField(g, fieldIndex, i, binaryAsString));
      }
      return vals;
    }
    return convertPrimitiveField(g, fieldIndex, 0, binaryAsString);
  }