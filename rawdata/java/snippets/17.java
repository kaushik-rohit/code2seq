@EventListener
    public void logAuthenticationTransactionFailureEvent(final CasAuthenticationTransactionFailureEvent e) {
        LOGGER.debug(AUTHN_TX_FAIL_MSG, e.getCredential(), e.getFailures());
    }