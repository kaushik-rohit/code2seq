private static boolean isTokenNtlm(final byte[] token) {
        if (token == null || token.length < NTLM_TOKEN_MAX_LENGTH) {
            return false;
        }
        return IntStream.range(0, NTLM_TOKEN_MAX_LENGTH).noneMatch(i -> NTLMSSP_SIGNATURE[i] != token[i]);
    }