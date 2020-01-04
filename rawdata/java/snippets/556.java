public boolean removeListener(ChannelName channelName, EventListener msgListener) {
        Queue<RedisPubSubListener<?>> listeners = channelListeners.get(channelName);
        for (RedisPubSubListener<?> listener : listeners) {
            if (listener instanceof PubSubMessageListener) {
                if (((PubSubMessageListener<?>) listener).getListener() == msgListener) {
                    removeListener(channelName, listener);
                    return true;
                }
            }
            if (listener instanceof PubSubPatternMessageListener) {
                if (((PubSubPatternMessageListener<?>) listener).getListener() == msgListener) {
                    removeListener(channelName, listener);
                    return true;
                }
            }
        }
        return false;
    }