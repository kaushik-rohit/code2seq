public static void printAvailableImage(final Image image) {
        final Subscription subscription = image.subscription();
        System.out.println(String.format("Available image on %s streamId=%d sessionId=%d from %s",
                        subscription.channel(), subscription.streamId(), image.sessionId(), image.sourceIdentity()));
    }