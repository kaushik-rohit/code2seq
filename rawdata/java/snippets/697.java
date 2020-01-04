public static Charset getCharset(HttpMessage message, Charset defaultCharset) {
        CharSequence contentTypeValue = message.headers().get(HttpHeaderNames.CONTENT_TYPE);
        if (contentTypeValue != null) {
            return getCharset(contentTypeValue, defaultCharset);
        } else {
            return defaultCharset;
        }
    }