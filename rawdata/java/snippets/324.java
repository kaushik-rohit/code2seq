protected SecurityToken getSecurityTokenFromRequest(final HttpServletRequest request) {
        val cookieValue = wsFederationRequestConfigurationContext.getTicketGrantingTicketCookieGenerator().retrieveCookieValue(request);
        if (StringUtils.isNotBlank(cookieValue)) {
            val tgt = wsFederationRequestConfigurationContext.getTicketRegistry().getTicket(cookieValue, TicketGrantingTicket.class);
            if (tgt != null) {
                val sts = tgt.getDescendantTickets().stream()
                    .filter(t -> t.startsWith(SecurityTokenTicket.PREFIX))
                    .findFirst()
                    .orElse(null);
                if (StringUtils.isNotBlank(sts)) {
                    val stt = wsFederationRequestConfigurationContext.getTicketRegistry().getTicket(sts, SecurityTokenTicket.class);
                    if (stt == null || stt.isExpired()) {
                        LOGGER.warn("Security token ticket [{}] is not found or has expired", sts);
                        return null;
                    }
                    if (stt.getSecurityToken().isExpired()) {
                        LOGGER.warn("Security token linked to ticket [{}] has expired", sts);
                        return null;
                    }
                    return stt.getSecurityToken();
                }
            }
        }
        return null;
    }