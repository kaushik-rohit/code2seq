@Override
  public LookupExtractor get()
  {
    final Lock readLock = startStopSync.readLock();
    try {
      readLock.lockInterruptibly();
    }
    catch (InterruptedException e) {
      throw new RuntimeException(e);
    }
    try {
      if (entry == null) {
        throw new ISE("Factory [%s] not started", extractorID);
      }
      final CacheScheduler.CacheState cacheState = entry.getCacheState();
      if (cacheState instanceof CacheScheduler.NoCache) {
        final String noCacheReason = ((CacheScheduler.NoCache) cacheState).name();
        throw new ISE("%s: %s, extractorID = %s", entry, noCacheReason, extractorID);
      }
      CacheScheduler.VersionedCache versionedCache = (CacheScheduler.VersionedCache) cacheState;
      Map<String, String> map = versionedCache.getCache();
      final byte[] v = StringUtils.toUtf8(versionedCache.getVersion());
      final byte[] id = StringUtils.toUtf8(extractorID);
      return new MapLookupExtractor(map, isInjective())
      {
        @Override
        public byte[] getCacheKey()
        {
          return ByteBuffer
              .allocate(CLASS_CACHE_KEY.length + id.length + 1 + v.length + 1 + 1)
              .put(CLASS_CACHE_KEY)
              .put(id).put((byte) 0xFF)
              .put(v).put((byte) 0xFF)
              .put(isOneToOne() ? (byte) 1 : (byte) 0)
              .array();
        }
      };
    }
    finally {
      readLock.unlock();
    }
  }