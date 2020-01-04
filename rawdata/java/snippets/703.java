public void markExecuted(@NonNull String nodeName, boolean executed) {

        states.get(nodeName).setExecuted(executed);
    }