public int getTermFrequency(String term)
    {
        TermFrequency termFrequency = trieSingle.get(term);
        if (termFrequency == null) return 0;
        return termFrequency.getValue();
    }