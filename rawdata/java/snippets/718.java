public CacheKeyBuilder appendStrings(Collection<String> input)
  {
    appendItem(STRING_LIST_KEY, stringCollectionToByteArray(input, true));
    return this;
  }