public SDVariable randomExponential(double lambda, SDVariable shape) {
        return new RandomExponential(sameDiff(), shape, lambda).outputVariable();
    }