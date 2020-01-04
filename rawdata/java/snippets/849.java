public int execute(final String user, final List<String> command) throws IOException {
    log.info("Command: " + command);
    final Process process = new ProcessBuilder()
        .command(constructExecuteAsCommand(user, command))
        .inheritIO()
        .start();

    int exitCode;
    try {
      exitCode = process.waitFor();
    } catch (final InterruptedException e) {
      log.error(e.getMessage(), e);
      exitCode = 1;
    }
    return exitCode;
  }