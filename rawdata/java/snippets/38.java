protected Date getFailureInRangeCutOffDate() {
        val cutoff = ZonedDateTime.now(ZoneOffset.UTC).minusSeconds(configurationContext.getFailureRangeInSeconds());
        return DateTimeUtils.timestampOf(cutoff);
    }