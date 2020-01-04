public static CharsetEncoder encoder(Charset charset) {
        checkNotNull(charset, "charset");

        Map<Charset, CharsetEncoder> map = InternalThreadLocalMap.get().charsetEncoderCache();
        CharsetEncoder e = map.get(charset);
        if (e != null) {
            e.reset().onMalformedInput(CodingErrorAction.REPLACE).onUnmappableCharacter(CodingErrorAction.REPLACE);
            return e;
        }

        e = encoder(charset, CodingErrorAction.REPLACE, CodingErrorAction.REPLACE);
        map.put(charset, e);
        return e;
    }