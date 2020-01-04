@Override
    public void write(ChannelHandlerContext ctx, Object msg, ChannelPromise promise) {
        if (msg instanceof Http2DataFrame) {
            Http2DataFrame dataFrame = (Http2DataFrame) msg;
            encoder().writeData(ctx, dataFrame.stream().id(), dataFrame.content(),
                    dataFrame.padding(), dataFrame.isEndStream(), promise);
        } else if (msg instanceof Http2HeadersFrame) {
            writeHeadersFrame(ctx, (Http2HeadersFrame) msg, promise);
        } else if (msg instanceof Http2WindowUpdateFrame) {
            Http2WindowUpdateFrame frame = (Http2WindowUpdateFrame) msg;
            Http2FrameStream frameStream = frame.stream();
            // It is legit to send a WINDOW_UPDATE frame for the connection stream. The parent channel doesn't attempt
            // to set the Http2FrameStream so we assume if it is null the WINDOW_UPDATE is for the connection stream.
            try {
                if (frameStream == null) {
                    increaseInitialConnectionWindow(frame.windowSizeIncrement());
                } else {
                    consumeBytes(frameStream.id(), frame.windowSizeIncrement());
                }
                promise.setSuccess();
            } catch (Throwable t) {
                promise.setFailure(t);
            }
        } else if (msg instanceof Http2ResetFrame) {
            Http2ResetFrame rstFrame = (Http2ResetFrame) msg;
            encoder().writeRstStream(ctx, rstFrame.stream().id(), rstFrame.errorCode(), promise);
        } else if (msg instanceof Http2PingFrame) {
            Http2PingFrame frame = (Http2PingFrame) msg;
            encoder().writePing(ctx, frame.ack(), frame.content(), promise);
        } else if (msg instanceof Http2SettingsFrame) {
            encoder().writeSettings(ctx, ((Http2SettingsFrame) msg).settings(), promise);
        } else if (msg instanceof Http2SettingsAckFrame) {
            // In the event of manual SETTINGS ACK is is assumed the encoder will apply the earliest received but not
            // yet ACKed settings.
            encoder().writeSettingsAck(ctx, promise);
        } else if (msg instanceof Http2GoAwayFrame) {
            writeGoAwayFrame(ctx, (Http2GoAwayFrame) msg, promise);
        } else if (msg instanceof Http2UnknownFrame) {
            Http2UnknownFrame unknownFrame = (Http2UnknownFrame) msg;
            encoder().writeFrame(ctx, unknownFrame.frameType(), unknownFrame.stream().id(),
                    unknownFrame.flags(), unknownFrame.content(), promise);
        } else if (!(msg instanceof Http2Frame)) {
            ctx.write(msg, promise);
        } else {
            ReferenceCountUtil.release(msg);
            throw new UnsupportedMessageTypeException(msg);
        }
    }