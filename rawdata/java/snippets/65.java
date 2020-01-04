private boolean canWriteInCurrentWorkingDirectory(final String effectiveUser)
      throws IOException {
    final ExecuteAsUser executeAsUser = new ExecuteAsUser(
        this.getSysProps().getString(AZKABAN_SERVER_NATIVE_LIB_FOLDER));
    final List<String> checkIfUserCanWriteCommand = Arrays
        .asList(CREATE_FILE, getWorkingDirectory() + "/" + TEMP_FILE_NAME);
    final int result = executeAsUser.execute(effectiveUser, checkIfUserCanWriteCommand);
    return result == SUCCESSFUL_EXECUTION;
  }