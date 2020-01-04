@Nonnull
    public static String loadFile(@Nonnull File logfile, @Nonnull Charset charset) throws IOException {
        // Note: Until charset handling is resolved (e.g. by implementing
        // https://issues.jenkins-ci.org/browse/JENKINS-48923 ), this method
        // must be able to handle character encoding errors. As reported at
        // https://issues.jenkins-ci.org/browse/JENKINS-49112 Run.getLog() calls
        // loadFile() to fully read the generated log file. This file might
        // contain unmappable and/or malformed byte sequences. We need to make
        // sure that in such cases, no CharacterCodingException is thrown.
        //
        // One approach that cannot be used is to call Files.newBufferedReader()
        // because there is a difference in how an InputStreamReader constructed
        // from a Charset and the reader returned by Files.newBufferedReader()
        // handle malformed and unmappable byte sequences for the specified
        // encoding; the latter is more picky and will throw an exception.
        // See: https://issues.jenkins-ci.org/browse/JENKINS-49060?focusedCommentId=325989&page=com.atlassian.jira.plugin.system.issuetabpanels:comment-tabpanel#comment-325989
        try {
            return FileUtils.readFileToString(logfile, charset);
        } catch (FileNotFoundException e) {
            return "";
        } catch (Exception e) {
            throw new IOException("Failed to fully read " + logfile, e);
        }
    }