public void shutdown() {
        /**
         * Probably we don't need this method in practice
         */
        if (initLocker.get() && shutdownLocker.compareAndSet(false, true)) {
            // do shutdown
            log.info("Shutting down transport...");

            // we just sending out ShutdownRequestMessage
            //transport.sendMessage(new ShutdownRequestMessage());
            transport.shutdown();

            executor.shutdown();
            initFinished.set(false);
            initLocker.set(false);
            shutdownLocker.set(false);
        }
    }