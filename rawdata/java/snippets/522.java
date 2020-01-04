public <T extends Evaluation> T evaluate(DataSetIterator iterator) {
        return (T)evaluate(iterator, (List<String>)null);
    }