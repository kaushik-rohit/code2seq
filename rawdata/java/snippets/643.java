public String getURIReference() throws URIException {
        char[] uriReference = getRawURIReference();
        return (uriReference == null) ? null : decode(uriReference,
                getProtocolCharset());
    }