public static Vec numericToStringVec(Vec src) {
    if (src.isCategorical() || src.isUUID())
      throw new H2OIllegalValueException("Cannot convert a non-numeric column"
          + " using numericToStringVec() ",src);
    Vec res = new MRTask() {
      @Override
      public void map(Chunk chk, NewChunk newChk) {
        if (chk instanceof C0DChunk) { // all NAs
          for (int i=0; i < chk._len; i++)
            newChk.addNA();
        } else {
          for (int i=0; i < chk._len; i++) {
            if (!chk.isNA(i))
              newChk.addStr(PrettyPrint.number(chk, chk.atd(i), 4));
            else
              newChk.addNA();
          }
        }
      }
    }.doAll(Vec.T_STR, src).outputFrame().anyVec();
    assert res != null;
    return res;
  }