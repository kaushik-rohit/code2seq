public double iterateSample(T w1, T w2, double score) {
        INDArray w1Vector = syn0.slice(w1.getIndex());
        INDArray w2Vector = syn0.slice(w2.getIndex());
        //prediction: input + bias
        if (w1.getIndex() < 0 || w1.getIndex() >= syn0.rows())
            throw new IllegalArgumentException("Illegal index for word " + w1.getLabel());
        if (w2.getIndex() < 0 || w2.getIndex() >= syn0.rows())
            throw new IllegalArgumentException("Illegal index for word " + w2.getLabel());


        //w1 * w2 + bias
        double prediction = Nd4j.getBlasWrapper().dot(w1Vector, w2Vector);
        prediction += bias.getDouble(w1.getIndex()) + bias.getDouble(w2.getIndex());

        double weight = Math.pow(Math.min(1.0, (score / maxCount)), xMax);

        double fDiff = score > xMax ? prediction : weight * (prediction - Math.log(score));
        if (Double.isNaN(fDiff))
            fDiff = Nd4j.EPS_THRESHOLD;
        //amount of change
        double gradient = fDiff;

        //note the update step here: the gradient is
        //the gradient of the OPPOSITE word
        //for adagrad we will use the index of the word passed in
        //for the gradient calculation we will use the context vector
        update(w1, w1Vector, w2Vector, gradient);
        update(w2, w2Vector, w1Vector, gradient);
        return fDiff;



    }