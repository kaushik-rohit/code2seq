public static void deleteRecursive(@Nonnull File dir) throws IOException {
        deleteRecursive(fileToPath(dir), PathRemover.PathChecker.ALLOW_ALL);
    }