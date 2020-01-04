protected Principal resolvePrincipal(final AuthenticationHandler handler, final PrincipalResolver resolver,
                                         final Credential credential, final Principal principal) {
        if (resolver.supports(credential)) {
            try {
                val p = resolver.resolve(credential, Optional.ofNullable(principal), Optional.ofNullable(handler));
                LOGGER.debug("[{}] resolved [{}] from [{}]", resolver, p, credential);
                return p;
            } catch (final Exception e) {
                LOGGER.error("[{}] failed to resolve principal from [{}]", resolver, credential, e);
            }
        } else {
            LOGGER.warn(
                "[{}] is configured to use [{}] but it does not support [{}], which suggests a configuration problem.",
                handler.getName(), resolver, credential);
        }
        return null;
    }