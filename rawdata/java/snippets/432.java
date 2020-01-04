public void truncateVocabulary(int threshold) {
        logger.debug("Truncating vocabulary to minWordFrequency: [" + threshold + "]");
        Set<String> keyset = vocabulary.keySet();
        for (String word : keyset) {
            VocabularyWord vw = vocabulary.get(word);

            // please note: we're not applying threshold to SPECIAL words
            if (!vw.isSpecial() && vw.getCount() < threshold) {
                vocabulary.remove(word);
                if (vw.getHuffmanNode() != null)
                    idxMap.remove(vw.getHuffmanNode().getIdx());
            }
        }
    }