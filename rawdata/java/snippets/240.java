public static LogEvent prepareLogEvent(final LogEvent logEvent) {
        val messageModified = TicketIdSanitizationUtils.sanitize(logEvent.getMessage().getFormattedMessage());
        val message = new SimpleMessage(messageModified);
        val newLogEventBuilder = Log4jLogEvent.newBuilder()
            .setLevel(logEvent.getLevel())
            .setLoggerName(logEvent.getLoggerName())
            .setLoggerFqcn(logEvent.getLoggerFqcn())
            .setContextData(new SortedArrayStringMap(logEvent.getContextData()))
            .setContextStack(logEvent.getContextStack())
            .setEndOfBatch(logEvent.isEndOfBatch())
            .setIncludeLocation(logEvent.isIncludeLocation())
            .setMarker(logEvent.getMarker())
            .setMessage(message)
            .setNanoTime(logEvent.getNanoTime())
            .setThreadName(logEvent.getThreadName())
            .setThrownProxy(logEvent.getThrownProxy())
            .setThrown(logEvent.getThrown())
            .setTimeMillis(logEvent.getTimeMillis());

        try {
            newLogEventBuilder.setSource(logEvent.getSource());
        } catch (final Exception e) {
            newLogEventBuilder.setSource(null);
        }
        return newLogEventBuilder.build();
    }