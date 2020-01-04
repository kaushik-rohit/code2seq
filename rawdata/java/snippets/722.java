public static List<Pair<Double,Integer>> sortCandidates(INDArray x,INDArray X,
                                                            List<Integer> candidates,
                                                            String similarityFunction) {
        int prevIdx = -1;
        List<Pair<Double,Integer>> ret = new ArrayList<>();
        for(int i = 0; i < candidates.size(); i++) {
            if(candidates.get(i) != prevIdx) {
                ret.add(Pair.of(computeDistance(similarityFunction,X.slice(candidates.get(i)),x),candidates.get(i)));
            }

            prevIdx = i;
        }


        Collections.sort(ret, new Comparator<Pair<Double, Integer>>() {
            @Override
            public int compare(Pair<Double, Integer> doubleIntegerPair, Pair<Double, Integer> t1) {
                return Doubles.compare(doubleIntegerPair.getFirst(),t1.getFirst());
            }
        });

        return ret;
    }