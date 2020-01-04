public void addUUID( long lo, long hi ) {
    if (C16Chunk.isNA(lo, hi)) {
      addNA();
      return;
    }
    if( _ms==null || _ds== null || _sparseLen >= _ms.len() )
      append2slowUUID();
    _ms.set(_sparseLen,lo);
    _ds[_sparseLen] = Double.longBitsToDouble(hi);
    if (_id != null) _id[_sparseLen] = _len;
    _sparseLen++;
    _len++;
    assert _sparseLen <= _len;
  }