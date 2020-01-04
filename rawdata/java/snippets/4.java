public static void reloadLibrary(String key) {
        if (key.startsWith(DicLibrary.DEFAULT)) {
            DicLibrary.reload(key);
        } else if (key.startsWith(StopLibrary.DEFAULT)) {
            StopLibrary.reload(key);
        } else if (key.startsWith(SynonymsLibrary.DEFAULT)) {
            SynonymsLibrary.reload(key);
        } else if (key.startsWith(AmbiguityLibrary.DEFAULT)) {
            AmbiguityLibrary.reload(key);
        } else if (key.startsWith(CrfLibrary.DEFAULT)) {
            CrfLibrary.reload(key);
        } else {
            throw new LibraryException(key + " type err must start with dic,stop,ambiguity,synonyms");
        }
    }