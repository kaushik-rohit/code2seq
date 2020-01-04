public static CompletableFuture<Void> sendResponse(
			@Nonnull ChannelHandlerContext channelHandlerContext,
			boolean keepAlive,
			@Nonnull String message,
			@Nonnull HttpResponseStatus statusCode,
			@Nonnull Map<String, String> headers) {
		HttpResponse response = new DefaultHttpResponse(HTTP_1_1, statusCode);

		response.headers().set(CONTENT_TYPE, RestConstants.REST_CONTENT_TYPE);

		for (Map.Entry<String, String> headerEntry : headers.entrySet()) {
			response.headers().set(headerEntry.getKey(), headerEntry.getValue());
		}

		if (keepAlive) {
			response.headers().set(CONNECTION, HttpHeaders.Values.KEEP_ALIVE);
		}

		byte[] buf = message.getBytes(ConfigConstants.DEFAULT_CHARSET);
		ByteBuf b = Unpooled.copiedBuffer(buf);
		HttpHeaders.setContentLength(response, buf.length);

		// write the initial line and the header.
		channelHandlerContext.write(response);

		channelHandlerContext.write(b);

		ChannelFuture lastContentFuture = channelHandlerContext.writeAndFlush(LastHttpContent.EMPTY_LAST_CONTENT);

		// close the connection, if no keep-alive is needed
		if (!keepAlive) {
			lastContentFuture.addListener(ChannelFutureListener.CLOSE);
		}

		return toCompletableFuture(lastContentFuture);
	}