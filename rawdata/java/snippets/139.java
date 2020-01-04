protected void handleServerHeaderDecodeSizeError(ChannelHandlerContext ctx, Http2Stream stream) {
        encoder().writeHeaders(ctx, stream.id(), HEADERS_TOO_LARGE_HEADERS, 0, true, ctx.newPromise());
    }