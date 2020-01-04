public static double[] toPreds(double in[], float[] out, double[] preds,
                          int nclasses, double[] priorClassDistrib, double defaultThreshold) {
    if (nclasses > 2) {
      for (int i = 0; i < out.length; ++i)
        preds[1 + i] = out[i];
      preds[0] = GenModel.getPrediction(preds, priorClassDistrib, in, defaultThreshold);
    } else if (nclasses==2){
      preds[1] = 1f - out[0];
      preds[2] = out[0];
      preds[0] = GenModel.getPrediction(preds, priorClassDistrib, in, defaultThreshold);
    } else {
      preds[0] = out[0];
    }
    return preds;
  }