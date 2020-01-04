public static SearchRequest newLdaptiveSearchRequest(final String baseDn,
                                                         final SearchFilter filter,
                                                         final String[] binaryAttributes,
                                                         final String[] returnAttributes) {
        val sr = new SearchRequest(baseDn, filter);
        sr.setBinaryAttributes(binaryAttributes);
        sr.setReturnAttributes(returnAttributes);
        sr.setSearchScope(SearchScope.SUBTREE);
        return sr;
    }