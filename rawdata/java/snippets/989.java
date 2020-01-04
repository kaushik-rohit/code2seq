@Override
    public MultiDataSet next() {
        val features = new ArrayList<INDArray>();
        val labels = new ArrayList<INDArray>();
        val featuresMask = new ArrayList<INDArray>();
        val labelsMask = new ArrayList<INDArray>();

        boolean hasFM = false;
        boolean hasLM = false;

        int cnt = 0;
        for (val i: iterators) {
            val ds = i.next();

            features.add(ds.getFeatures());
            featuresMask.add(ds.getFeaturesMaskArray());

            if (outcome < 0 || cnt == outcome) {
                labels.add(ds.getLabels());
                labelsMask.add(ds.getLabelsMaskArray());
            }

            if (ds.getFeaturesMaskArray() != null)
                hasFM = true;

            if (ds.getLabelsMaskArray() != null)
                hasLM = true;

            cnt++;
        }

        INDArray[] fm = hasFM ? featuresMask.toArray(new INDArray[0]) : null;
        INDArray[] lm = hasLM ? labelsMask.toArray(new INDArray[0]) : null;

        val mds = new org.nd4j.linalg.dataset.MultiDataSet(features.toArray(new INDArray[0]), labels.toArray(new INDArray[0]), fm, lm);

        if (preProcessor != null)
            preProcessor.preProcess(mds);

        return mds;
    }