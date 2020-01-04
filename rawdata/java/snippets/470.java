@DeleteOperation
    public Map<String, Object> destroySsoSessions(final String type) {

        val sessionsMap = new HashMap<String, Object>();
        val failedTickets = new HashMap<String, String>();
        val option = SsoSessionReportOptions.valueOf(type);
        val collection = getActiveSsoSessions(option);
        collection
            .stream()
            .map(sso -> sso.get(SsoSessionAttributeKeys.TICKET_GRANTING_TICKET.toString()).toString())
            .forEach(ticketGrantingTicket -> {
                try {
                    this.centralAuthenticationService.destroyTicketGrantingTicket(ticketGrantingTicket);
                } catch (final Exception e) {
                    LOGGER.error(e.getMessage(), e);
                    failedTickets.put(ticketGrantingTicket, e.getMessage());
                }
            });
        if (failedTickets.isEmpty()) {
            sessionsMap.put(STATUS, HttpServletResponse.SC_OK);
        } else {
            sessionsMap.put(STATUS, HttpServletResponse.SC_INTERNAL_SERVER_ERROR);
            sessionsMap.put("failedTicketGrantingTickets", failedTickets);
        }
        return sessionsMap;
    }