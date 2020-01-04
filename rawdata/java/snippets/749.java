public SDVariable dotProductAttention(SDVariable queries, SDVariable keys, SDVariable values, SDVariable mask, boolean scaled){
        return dotProductAttention(null, queries, keys, values, mask, scaled);
    }