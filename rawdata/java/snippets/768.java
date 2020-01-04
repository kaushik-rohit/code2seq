protected AuthnRequest retrieveSamlAuthenticationRequestFromHttpRequest(final HttpServletRequest request) throws Exception {
        LOGGER.debug("Retrieving authentication request from scope");
        val requestValue = request.getParameter(SamlProtocolConstants.PARAMETER_SAML_REQUEST);
        if (StringUtils.isBlank(requestValue)) {
            throw new IllegalArgumentException("SAML request could not be determined from the authentication request");
        }
        val encodedRequest = EncodingUtils.decodeBase64(requestValue.getBytes(StandardCharsets.UTF_8));
        return (AuthnRequest) XMLObjectSupport.unmarshallFromInputStream(samlProfileHandlerConfigurationContext.getOpenSamlConfigBean().getParserPool(),
            new ByteArrayInputStream(encodedRequest));
    }