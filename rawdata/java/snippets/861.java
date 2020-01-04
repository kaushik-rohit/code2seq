private void configureClearTextWithPriorKnowledge(SocketChannel ch) {
        ch.pipeline().addLast(connectionHandler,
            new PrefaceFrameWrittenEventHandler(),
            new UserEventLogger());
        configureEndOfPipeline(ch.pipeline());
    }