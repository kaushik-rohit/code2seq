public static int binomial(RandomGenerator rng, int n, double p) {
        if ((p < 0) || (p > 1)) {
            return 0;
        }
        int c = 0;
        for (int i = 0; i < n; i++) {
            if (rng.nextDouble() < p) {
                c++;
            }
        }
        return c;
    }