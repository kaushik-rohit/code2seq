@edu.umd.cs.findbugs.annotations.SuppressFBWarnings("LG_LOST_LOGGER_DUE_TO_WEAK_REFERENCE")
    private void installLogger() {
        Jenkins.logRecords = handler.getView();
        Logger.getLogger("").addHandler(handler);
    }