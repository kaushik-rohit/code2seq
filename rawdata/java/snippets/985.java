private boolean decodeBulkStringEndOfLine(ByteBuf in, List<Object> out) throws Exception {
        if (in.readableBytes() < RedisConstants.EOL_LENGTH) {
            return false;
        }
        readEndOfLine(in);
        out.add(FullBulkStringRedisMessage.EMPTY_INSTANCE);
        resetDecoder();
        return true;
    }