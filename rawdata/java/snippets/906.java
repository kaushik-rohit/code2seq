static List<HpackHeader> headers(HpackHeadersSize size, boolean limitToAscii) {
        return headersMap.get(new HeadersKey(size, limitToAscii));
    }