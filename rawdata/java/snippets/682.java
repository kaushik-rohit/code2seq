public List<String> findAllInContent(String content) {
        
        List<String> results = new LinkedList<String>();
        
        // First check for all simple exact occurrences
        for (BoyerMooreMatcher matcher : strings) {
            if (matcher.findInContent(content) >= 0)
                results.add(matcher.getPattern());
        }
        
        // Then check for all regex occurrences
        Matcher matcher;
        for (Pattern pattern : patterns) {
            matcher = pattern.matcher(content);
            if (matcher.find()) {
                results.add(content);
            }
        }
        
        return results;
    }