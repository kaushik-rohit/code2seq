@Override
    public String getNewTicketId(final String prefix) {
        val number = this.numericGenerator.getNextNumberAsString();
        val ticketBody = this.randomStringGenerator.getNewString().replace('_', '-');
        val origSuffix = StringUtils.defaultString(this.suffix);
        val finalizedSuffix = StringUtils.isEmpty(origSuffix) ? origSuffix : '-' + origSuffix;
        return prefix + '-' + number + '-' + ticketBody + finalizedSuffix;
    }