public final byte[] memOrLoad() {
    byte[] mem = _mem;          // Read once!
    if( mem != null ) return mem;
    Freezable pojo = _pojo;     // Read once!
    if( pojo != null )          // Has the POJO, make raw bytes
      return _mem = pojo.asBytes();
    if( _max == 0 ) return (_mem = new byte[0]);
    return (_mem = loadPersist());
  }