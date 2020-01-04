public ByteBuf remove(int bytes, ChannelPromise aggregatePromise) {
        return remove(channel.alloc(), bytes, aggregatePromise);
    }