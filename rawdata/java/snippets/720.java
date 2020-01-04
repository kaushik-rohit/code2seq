protected <T extends SAMLObject> void prepareSamlOutboundDestinationHandler(final MessageContext<T> outboundContext) throws Exception {
        val handlerDest = new SAMLOutboundDestinationHandler();
        handlerDest.initialize();
        handlerDest.invoke(outboundContext);
    }