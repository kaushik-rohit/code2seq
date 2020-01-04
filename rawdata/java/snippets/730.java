public void notifyNewMessage(Plugin plugin, HttpMessage message) {
        parentScanner.notifyNewMessage(message);
        notifyNewMessage(plugin);
    }