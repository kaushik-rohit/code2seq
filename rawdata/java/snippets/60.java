@Nonnull
    public static ACLContext as(@Nonnull Authentication auth) {
        final ACLContext context = new ACLContext(SecurityContextHolder.getContext());
        SecurityContextHolder.setContext(new NonSerializableSecurityContext(auth));
        return context;
    }