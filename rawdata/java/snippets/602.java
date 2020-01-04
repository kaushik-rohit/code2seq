@Nonnull
    @Deprecated
    public static String loadFile(@Nonnull File logfile) throws IOException {
        return loadFile(logfile, Charset.defaultCharset());
    }