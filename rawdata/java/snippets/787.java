public static List<String> extractSummary(String document, int size, String sentence_separator)
    {
        return TextRankSentence.getTopSentenceList(document, size, sentence_separator);
    }