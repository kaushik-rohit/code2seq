public static void fpropMiniBatch(long seed, Neurons[] neurons, DeepLearningModelInfo minfo,
                                    DeepLearningModelInfo consensus_minfo, boolean training, double[] responses, double[] offset, int n) {
    // Forward propagation
    for (int i=1; i<neurons.length; ++i)
      neurons[i].fprop(seed, training, n);

    // Add offset (in link space) if applicable
    for (int mb=0;mb<n;++mb) {
      if (offset!=null && offset[mb] > 0) {
        assert (!minfo._classification); // Regression
        double[] m = minfo.data_info()._normRespMul;
        double[] s = minfo.data_info()._normRespSub;
        double mul = m == null ? 1 : m[0];
        double sub = s == null ? 0 : s[0];
        neurons[neurons.length - 1]._a[mb].add(0, ((offset[mb] - sub) * mul));
      }

      if (training) {
        // Compute the gradient at the output layer
        // auto-encoder: pass a dummy "response" (ignored)
        // otherwise: class label or regression target
        neurons[neurons.length - 1].setOutputLayerGradient(responses[mb], mb, n);

        // Elastic Averaging - set up helpers needed during back-propagation
        if (consensus_minfo != null) {
          for (int i = 1; i < neurons.length; i++) {
            neurons[i]._wEA = consensus_minfo.get_weights(i - 1);
            neurons[i]._bEA = consensus_minfo.get_biases(i - 1);
          }
        }
      }
    }
  }