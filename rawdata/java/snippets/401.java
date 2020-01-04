public RocCurve getRocCurve() {
        if (rocCurve != null) {
            return rocCurve;
        }

        if (isExact) {
            //Sort ascending. As we decrease threshold, more are predicted positive.
            //if(prob <= threshold> predict 0, otherwise predict 1
            //So, as we iterate from i=0..length, first 0 to i (inclusive) are predicted class 1, all others are predicted class 0
            INDArray pl = getProbAndLabelUsed();
            INDArray sorted = Nd4j.sortRows(pl, 0, false);
            INDArray isPositive = sorted.getColumn(1,true);
            INDArray isNegative = sorted.getColumn(1,true).rsub(1.0);

            INDArray cumSumPos = isPositive.cumsum(-1);
            INDArray cumSumNeg = isNegative.cumsum(-1);
            val length = sorted.size(0);

            INDArray t = Nd4j.create(DataType.DOUBLE, length + 2, 1);
            t.put(new INDArrayIndex[]{interval(1, length + 1), all()}, sorted.getColumn(0,true));

            INDArray fpr = Nd4j.create(DataType.DOUBLE, length + 2, 1);
            fpr.put(new INDArrayIndex[]{interval(1, length + 1), all()},
                    cumSumNeg.div(countActualNegative));

            INDArray tpr = Nd4j.create(DataType.DOUBLE, length + 2, 1);
            tpr.put(new INDArrayIndex[]{interval(1, length + 1), all()},
                    cumSumPos.div(countActualPositive));

            //Edge cases
            t.putScalar(0, 0, 1.0);
            fpr.putScalar(0, 0, 0.0);
            tpr.putScalar(0, 0, 0.0);
            fpr.putScalar(length + 1, 0, 1.0);
            tpr.putScalar(length + 1, 0, 1.0);


            double[] x_fpr_out = fpr.data().asDouble();
            double[] y_tpr_out = tpr.data().asDouble();
            double[] tOut = t.data().asDouble();

            //Note: we can have multiple FPR for a given TPR, and multiple TPR for a given FPR
            //These can be omitted, without changing the area (as long as we keep the edge points)
            if (rocRemoveRedundantPts) {
                Pair<double[][], int[][]> p = removeRedundant(tOut, x_fpr_out, y_tpr_out, null, null, null);
                double[][] temp = p.getFirst();
                tOut = temp[0];
                x_fpr_out = temp[1];
                y_tpr_out = temp[2];
            }

            this.rocCurve = new RocCurve(tOut, x_fpr_out, y_tpr_out);

            return rocCurve;
        } else {

            double[][] out = new double[3][thresholdSteps + 1];
            int i = 0;
            for (Map.Entry<Double, CountsForThreshold> entry : counts.entrySet()) {
                CountsForThreshold c = entry.getValue();
                double tpr = c.getCountTruePositive() / ((double) countActualPositive);
                double fpr = c.getCountFalsePositive() / ((double) countActualNegative);

                out[0][i] = c.getThreshold();
                out[1][i] = fpr;
                out[2][i] = tpr;
                i++;
            }
            return new RocCurve(out[0], out[1], out[2]);
        }
    }