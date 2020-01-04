public boolean filter(Term term) {

        if (!stop.isEmpty() && (stop.contains(term.getName()))) {
            return true;
        }

        if (!natureStop.isEmpty() && (natureStop.contains(term.natrue().natureStr))) {
            return true;
        }

        if (!regexList.isEmpty()) {
            for (Pattern stopwordPattern : regexList) {
                if (stopwordPattern.matcher(term.getName()).matches()) {
                    return true;
                }
            }
        }

        return false;
    }