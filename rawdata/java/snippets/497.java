private static int getTimeout(final Ticket ticket) {
        val ttl = ticket.getExpirationPolicy().getTimeToLive().intValue();
        if (ttl == 0) {
            return 1;
        }
        return ttl;
    }