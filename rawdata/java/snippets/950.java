public static FrameNodes findFrameNodes(Frame fr) {
    // Count on how many nodes the data resides
    boolean[] nodesHoldingFrame = new boolean[H2O.CLOUD.size()];
    Vec vec = fr.anyVec();
    for(int chunkNr = 0; chunkNr < vec.nChunks(); chunkNr++) {
      int home = vec.chunkKey(chunkNr).home_node().index();
      if (! nodesHoldingFrame[home])
        nodesHoldingFrame[home] = true;
    }
    return new FrameNodes(fr, nodesHoldingFrame);
  }