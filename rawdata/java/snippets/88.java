public void transferBackToVocabCache(VocabCache cache, boolean emptyHolder) {
        if (!(cache instanceof InMemoryLookupCache))
            throw new IllegalStateException("Sorry, only InMemoryLookupCache use implemented.");

        // make sure that huffman codes are updated before transfer
        List<VocabularyWord> words = words(); //updateHuffmanCodes();

        for (VocabularyWord word : words) {
            if (word.getWord().isEmpty())
                continue;
            VocabWord vocabWord = new VocabWord(1, word.getWord());

            // if we're transferring full model, it CAN contain HistoricalGradient for AdaptiveGradient feature
            if (word.getHistoricalGradient() != null) {
                INDArray gradient = Nd4j.create(word.getHistoricalGradient());
                vocabWord.setHistoricalGradient(gradient);
            }

            // put VocabWord into both Tokens and Vocabs maps
            ((InMemoryLookupCache) cache).getVocabs().put(word.getWord(), vocabWord);
            ((InMemoryLookupCache) cache).getTokens().put(word.getWord(), vocabWord);


            // update Huffman tree information
            if (word.getHuffmanNode() != null) {
                vocabWord.setIndex(word.getHuffmanNode().getIdx());
                vocabWord.setCodeLength(word.getHuffmanNode().getLength());
                vocabWord.setPoints(arrayToList(word.getHuffmanNode().getPoint(), word.getHuffmanNode().getLength()));
                vocabWord.setCodes(arrayToList(word.getHuffmanNode().getCode(), word.getHuffmanNode().getLength()));

                // put word into index
                cache.addWordToIndex(word.getHuffmanNode().getIdx(), word.getWord());
            }

            //update vocabWord counter. substract 1, since its the base value for any token
            // >1 hack is required since VocabCache impl imples 1 as base word count, not 0
            if (word.getCount() > 1)
                cache.incrementWordCount(word.getWord(), word.getCount() - 1);
        }

        // at this moment its pretty safe to nullify all vocabs.
        if (emptyHolder) {
            idxMap.clear();
            vocabulary.clear();
        }
    }