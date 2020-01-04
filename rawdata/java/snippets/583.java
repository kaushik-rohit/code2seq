@Override
    public boolean addToken(T element) {
        boolean ret = false;
        T oldElement = vocabulary.putIfAbsent(element.getStorageId(), element);
        if (oldElement == null) {
            //putIfAbsent added our element
            if (element.getLabel() != null) {
                extendedVocabulary.put(element.getLabel(), element);
            }
            oldElement = element;
            ret = true;
        } else {
            oldElement.incrementSequencesCount(element.getSequencesCount());
            oldElement.increaseElementFrequency((int) element.getElementFrequency());
        }
        totalWordCount.addAndGet((long) oldElement.getElementFrequency());
        return ret;
    }