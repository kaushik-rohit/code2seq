public SubGraphPredicate withInputSubgraph(int inputNum, @NonNull OpPredicate opPredicate){
        opInputSubgraphPredicates.put(inputNum, opPredicate);
        return this;
    }