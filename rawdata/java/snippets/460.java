@SuppressWarnings("UnusedParameters")
    protected ByteBuf extractObject(ChannelHandlerContext ctx, ByteBuf buffer, int index, int length) {
        return buffer.retainedSlice(index, length);
    }