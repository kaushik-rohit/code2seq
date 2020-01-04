@Deprecated
    public static void writeWordVectors(@NonNull ParagraphVectors vectors, @NonNull File path) {
        try (FileOutputStream fos = new FileOutputStream(path)) {
            writeWordVectors(vectors, fos);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }