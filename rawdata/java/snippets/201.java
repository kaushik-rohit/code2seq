double[][] initial_centers(KMeansModel model, final Vec[] vecs, final double[] means, final double[] mults, final int[] modes, int k) {

      // Categoricals use a different distance metric than numeric columns.
      model._output._categorical_column_count=0;
      _isCats = new String[vecs.length][];
      for( int v=0; v<vecs.length; v++ ) {
        _isCats[v] = vecs[v].isCategorical() ? new String[0] : null;
        if (_isCats[v] != null) model._output._categorical_column_count++;
      }
      Random rand = water.util.RandomUtils.getRNG(_parms._seed-1);
      double centers[][];    // Cluster centers
      if( null != _parms._user_points ) { // User-specified starting points
        Frame user_points = _parms._user_points.get();
        int numCenters = (int)user_points.numRows();
        int numCols = model._output.nfeatures();
        centers = new double[numCenters][numCols];
        Vec[] centersVecs = user_points.vecs();
        // Get the centers and standardize them if requested
        for (int r=0; r<numCenters; r++) {
          for (int c=0; c<numCols; c++){
            centers[r][c] = centersVecs[c].at(r);
            centers[r][c] = Kmeans_preprocessData(centers[r][c], c, means, mults, modes);
          }
        }
      }
      else { // Random, Furthest, or PlusPlus initialization
        if (_parms._init == Initialization.Random) {
          // Initialize all cluster centers to random rows
          centers = new double[k][model._output.nfeatures()];
          for (double[] center : centers)
            randomRow(vecs, rand, center, means, mults, modes);
        } else {
          centers = new double[1][model._output.nfeatures()];
          // Initialize first cluster center to random row
          randomRow(vecs, rand, centers[0], means, mults, modes);

          model._output._iterations = 0;
          while (model._output._iterations < 5) {
            // Sum squares distances to cluster center
            SumSqr sqr = new SumSqr(centers, means, mults, modes, _isCats).doAll(vecs);

            // Sample with probability inverse to square distance
            Sampler sampler = new Sampler(centers, means, mults, modes, _isCats, sqr._sqr, k * 3, _parms.getOrMakeRealSeed(), hasWeightCol()).doAll(vecs);
            centers = ArrayUtils.append(centers, sampler._sampled);

            // Fill in sample centers into the model
            model._output._centers_raw = destandardize(centers, _isCats, means, mults);
            model._output._tot_withinss = sqr._sqr / _train.numRows();

            model._output._iterations++;     // One iteration done

            model.update(_job); // Make early version of model visible, but don't update progress using update(1)
            if (stop_requested()) {
              if (timeout())
                warn("_max_runtime_secs reached.", "KMeans exited before finishing all iterations.");
              break; // Stopped/cancelled
            }
          }
          // Recluster down to k cluster centers
          centers = recluster(centers, rand, k, _parms._init, _isCats);
          model._output._iterations = 0; // Reset iteration count
        }
      }
      assert(centers.length == k);
      return centers;
    }