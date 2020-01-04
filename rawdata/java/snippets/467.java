public OutputStream decorateLogger(AbstractBuild build, OutputStream logger) throws IOException, InterruptedException {
        if (Util.isOverridden(ConsoleLogFilter.class, getClass(), "decorateLogger", Run.class, OutputStream.class)) {
            // old client calling newer implementation. forward the call.
            return decorateLogger((Run) build, logger);
        } else {
            // happens only if the subtype fails to override neither decorateLogger method
            throw new AssertionError("The plugin '" + this.getClass().getName() + "' still uses " +
                    "deprecated decorateLogger(AbstractBuild,OutputStream) method. " +
                    "Update the plugin to use setUp(Run,OutputStream) instead.");
        }
    }