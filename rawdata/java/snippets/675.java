public double calculateAverageAuc() {
        double ret = 0.0;
        for (int i = 0; i < numLabels(); i++) {
            ret += calculateAUC(i);
        }

        return ret / (double) numLabels();
    }