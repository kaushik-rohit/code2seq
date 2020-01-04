static void ensurePrincipalAccessIsAllowedForService(final ServiceTicket serviceTicket,
                                                         final AuthenticationResult context,
                                                         final RegisteredService registeredService)
        throws UnauthorizedServiceException, PrincipalException {
        ensurePrincipalAccessIsAllowedForService(serviceTicket.getService(), registeredService, context.getAuthentication());
    }