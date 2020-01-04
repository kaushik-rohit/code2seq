public Summary toSummary(String query) {

        List<Term> parse = NlpAnalysis.parse(query).getTerms();

        List<Keyword> keywords = new ArrayList<>();
        for (Term term : parse) {
            if (FILTER_SET.contains(term.natrue().natureStr)) {
                continue;
            }
            keywords.add(new Keyword(term.getName(), term.termNatures().allFreq, 1));
        }

        return toSummary(keywords);
    }