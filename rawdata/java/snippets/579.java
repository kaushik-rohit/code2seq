@Override
    protected void verify(FullHttpResponse response) {
        final HttpResponseStatus status = HttpResponseStatus.SWITCHING_PROTOCOLS;
        final HttpHeaders headers = response.headers();

        if (!response.status().equals(status)) {
            throw new WebSocketHandshakeException("Invalid handshake response getStatus: " + response.status());
        }

        CharSequence upgrade = headers.get(HttpHeaderNames.UPGRADE);
        if (!HttpHeaderValues.WEBSOCKET.contentEqualsIgnoreCase(upgrade)) {
            throw new WebSocketHandshakeException("Invalid handshake response upgrade: " + upgrade);
        }

        if (!headers.containsValue(HttpHeaderNames.CONNECTION, HttpHeaderValues.UPGRADE, true)) {
            throw new WebSocketHandshakeException("Invalid handshake response connection: "
                    + headers.get(HttpHeaderNames.CONNECTION));
        }

        CharSequence accept = headers.get(HttpHeaderNames.SEC_WEBSOCKET_ACCEPT);
        if (accept == null || !accept.equals(expectedChallengeResponseString)) {
            throw new WebSocketHandshakeException(String.format(
                    "Invalid challenge. Actual: %s. Expected: %s", accept, expectedChallengeResponseString));
        }
    }