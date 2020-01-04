@Nonnull
    public Launcher createLauncher(TaskListener listener) {
        SlaveComputer c = getComputer();
        if (c == null) {
            listener.error("Issue with creating launcher for agent " + name + ". Computer has been disconnected");
            return new Launcher.DummyLauncher(listener);
        } else {
            // TODO: ideally all the logic below should be inside the SlaveComputer class with proper locking to prevent race conditions, 
            // but so far there is no locks for setNode() hence it requires serious refactoring
            
            // Ensure that the Computer instance still points to this node
            // Otherwise we may end up running the command on a wrong (reconnected) Node instance.
            Slave node = c.getNode();
            if (node != this) {
                String message = "Issue with creating launcher for agent " + name + ". Computer has been reconnected";
                if (LOGGER.isLoggable(Level.WARNING)) {
                    LOGGER.log(Level.WARNING, message, new IllegalStateException("Computer has been reconnected, this Node instance cannot be used anymore"));
                }
                return new Launcher.DummyLauncher(listener);
            }
            
            // RemoteLauncher requires an active Channel instance to operate correctly
            final Channel channel = c.getChannel();
            if (channel == null) { 
                reportLauncherCreateError("The agent has not been fully initialized yet",
                                         "No remoting channel to the agent OR it has not been fully initialized yet", listener);
                return new Launcher.DummyLauncher(listener);
            }
            if (channel.isClosingOrClosed()) {
                reportLauncherCreateError("The agent is being disconnected",
                                         "Remoting channel is either in the process of closing down or has closed down", listener);
                return new Launcher.DummyLauncher(listener);
            }
            final Boolean isUnix = c.isUnix();
            if (isUnix == null) {
                // isUnix is always set when the channel is not null, so it should never happen
                reportLauncherCreateError("The agent has not been fully initialized yet",
                                         "Cannot determing if the agent is a Unix one, the System status request has not completed yet. " +
                                         "It is an invalid channel state, please report a bug to Jenkins if you see it.", 
                                         listener);
                return new Launcher.DummyLauncher(listener);
            }
            
            return new RemoteLauncher(listener, channel, isUnix).decorateFor(this);
        }
    }