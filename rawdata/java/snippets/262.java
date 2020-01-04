public static int[] sampleOOBRows(int nrows, float rate, Random sampler, int[] oob) {
    int oobcnt = 0; // Number of oob rows
    Arrays.fill(oob, 0);
    for(int row = 0; row < nrows; row++) {
      if (sampler.nextFloat() >= rate) { // it is out-of-bag row
        oob[1+oobcnt++] = row;
        if (1+oobcnt>=oob.length) oob = Arrays.copyOf(oob, Math.round(1.2f*nrows+0.5f)+2);
      }
    }
    oob[0] = oobcnt;
    return oob;
  }