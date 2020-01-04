public static void putAuthentication(final Authentication authentication, final RequestContext ctx) {
        ctx.getConversationScope().put(PARAMETER_AUTHENTICATION, authentication);
    }