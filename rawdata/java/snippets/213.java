static byte[] RC4(final byte[] value, final byte[] key)
        throws AuthenticationException {
        try {
            final Cipher rc4 = Cipher.getInstance("RC4");
            rc4.init(Cipher.ENCRYPT_MODE, new SecretKeySpec(key, "RC4"));
            return rc4.doFinal(value);
        } catch (final Exception e) {
            throw new AuthenticationException(e.getMessage(), e);
        }
    }