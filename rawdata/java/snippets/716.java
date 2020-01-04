CompletableFuture<Integer> getNextStreamPosition() {
        return store.createEphemeralSequentialZNode(counterPath)
                    .thenApply(counterStr -> Integer.parseInt(counterStr.replace(counterPath, "")));
    }