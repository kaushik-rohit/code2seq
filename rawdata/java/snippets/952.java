private double compute_auc() {
    if (_fps[_nBins-1] == 0) return 1.0; //special case
    if (_tps[_nBins-1] == 0) return 0.0; //special case

    // All math is computed scaled by TP and FP.  We'll descale once at the
    // end.  Trapezoids from (tps[i-1],fps[i-1]) to (tps[i],fps[i])
    double tp0 = 0, fp0 = 0;
    double area = 0;
    for( int i=0; i<_nBins; i++ ) {
      area += (_fps[i]-fp0)*(_tps[i]+tp0)/2.0; // Trapezoid
      tp0 = _tps[i];  fp0 = _fps[i];
    }
    // Descale
    return area/_p/_n;
  }