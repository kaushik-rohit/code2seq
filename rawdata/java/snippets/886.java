private ValFrame rowwise(Env env, Frame fr, final AstPrimitive fun) {
    final String[] names = fr._names;

    final AstFunction scope = env._scope;  // Current execution scope; needed to lookup variables

    // do a single row of the frame to determine the size of the output.
    double[] ds = new double[fr.numCols()];
    for (int col = 0; col < fr.numCols(); ++col)
      ds[col] = fr.vec(col).at(0);
    int noutputs = fun.apply(env, env.stk(), new AstRoot[]{fun, new AstRow(ds, fr.names())}).getRow().length;

    Frame res = new MRTask() {
      @Override
      public void map(Chunk chks[], NewChunk[] nc) {
        double ds[] = new double[chks.length]; // Working row
        AstRoot[] asts = new AstRoot[]{fun, new AstRow(ds, names)}; // Arguments to be called; they are reused endlessly
        Session ses = new Session();                      // Session, again reused endlessly
        Env env = new Env(ses);
        env._scope = scope;                               // For proper namespace lookup
        for (int row = 0; row < chks[0]._len; row++) {
          for (int col = 0; col < chks.length; col++) // Fill the row
            ds[col] = chks[col].atd(row);
          try (Env.StackHelp stk_inner = env.stk()) {
            double[] valRow = fun.apply(env, stk_inner, asts).getRow(); // Make the call per-row
            for (int newCol = 0; newCol < nc.length; ++newCol)
              nc[newCol].addNum(valRow[newCol]);
          }
        }
        ses.end(null);        // Mostly for the sanity checks
      }
    }.doAll(noutputs, Vec.T_NUM, fr).outputFrame();
    return new ValFrame(res);
  }