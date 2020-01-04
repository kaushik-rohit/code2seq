public static VocabCache<VocabWord> readVocabCache(@NonNull File file) throws IOException {
        try (FileInputStream fis = new FileInputStream(file)) {
            return readVocabCache(fis);
        }
    }