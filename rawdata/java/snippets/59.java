public void addCommands(Iterable<Command> commands) {
		Assert.notNull(commands, "Commands must not be null");
		for (Command command : commands) {
			addCommand(command);
		}
	}