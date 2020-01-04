public static TicketGrantingTicket getTicketGrantingTicketFromRequest(final CasCookieBuilder ticketGrantingTicketCookieGenerator,
                                                                          final TicketRegistry ticketRegistry, final HttpServletRequest request) {
        val cookieValue = ticketGrantingTicketCookieGenerator.retrieveCookieValue(request);
        if (StringUtils.isNotBlank(cookieValue)) {
            val tgt = ticketRegistry.getTicket(cookieValue, TicketGrantingTicket.class);
            if (tgt != null && !tgt.isExpired()) {
                return tgt;
            }
        }
        return null;
    }