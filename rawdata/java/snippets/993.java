private void tasks() {
        Runnable r;
        while ( (r = sslEngine.getDelegatedTask()) != null) {
            r.run();
        }
        hs = sslEngine.getHandshakeStatus();
    }