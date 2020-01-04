TsiFrameProtector createFrameProtector(int maxFrameSize, ByteBufAllocator alloc) {
    unwrapper = null;
    return internalHandshaker.createFrameProtector(maxFrameSize, alloc);
  }