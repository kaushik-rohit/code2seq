static CLICommand setCurrent(CLICommand cmd) {
        CLICommand old = getCurrent();
        CURRENT_COMMAND.set(cmd);
        return old;
    }