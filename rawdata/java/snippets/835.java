static void handle(ChannelHandlerContext ctx, Http2Connection connection,
                              Http2FrameListener listener, FullHttpMessage message) throws Http2Exception {
        try {
            int streamId = getStreamId(connection, message.headers());
            Http2Stream stream = connection.stream(streamId);
            if (stream == null) {
                stream = connection.remote().createStream(streamId, false);
            }
            message.headers().set(HttpConversionUtil.ExtensionHeaderNames.SCHEME.text(), HttpScheme.HTTP.name());
            Http2Headers messageHeaders = HttpConversionUtil.toHttp2Headers(message, true);
            boolean hasContent = message.content().isReadable();
            boolean hasTrailers = !message.trailingHeaders().isEmpty();
            listener.onHeadersRead(
                    ctx, streamId, messageHeaders, 0, !(hasContent || hasTrailers));
            if (hasContent) {
                listener.onDataRead(ctx, streamId, message.content(), 0, !hasTrailers);
            }
            if (hasTrailers) {
                Http2Headers headers = HttpConversionUtil.toHttp2Headers(message.trailingHeaders(), true);
                listener.onHeadersRead(ctx, streamId, headers, 0, true);
            }
            stream.closeRemoteSide();
        } finally {
            message.release();
        }
    }