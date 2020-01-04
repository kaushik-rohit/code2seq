public void verifySamlProfileRequestIfNeeded(final RequestAbstractType profileRequest,
                                                 final SamlRegisteredServiceServiceProviderMetadataFacade adaptor,
                                                 final HttpServletRequest request,
                                                 final MessageContext context) throws Exception {

        verifySamlProfileRequestIfNeeded(profileRequest, adaptor.getMetadataResolver(), request, context);
    }