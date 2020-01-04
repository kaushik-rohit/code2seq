public static String resolveExecutionJarName(String workingDirectory,
      String userSpecifiedJarName, Logger log) {

    if (log.isDebugEnabled()) {
      String debugMsg = String.format(
          "Resolving execution jar name: working directory: %s,  user specified name: %s",
          workingDirectory, userSpecifiedJarName);
      log.debug(debugMsg);
    }

    // in case user decides to specify with abc.jar, instead of only abc
    if (userSpecifiedJarName.endsWith(".jar")) {
      userSpecifiedJarName = userSpecifiedJarName.replace(".jar", "");
    } else if (userSpecifiedJarName.endsWith(".py")) {
      userSpecifiedJarName = userSpecifiedJarName.replace(".py", "");
    }

    // can't use java 1.7 stuff, reverting to a slightly ugly implementation
    String userSpecifiedJarPath = String.format("%s/%s", workingDirectory, userSpecifiedJarName);
    int lastIndexOfSlash = userSpecifiedJarPath.lastIndexOf("/");
    final String jarPrefix = userSpecifiedJarPath.substring(lastIndexOfSlash + 1);
    final String dirName = userSpecifiedJarPath.substring(0, lastIndexOfSlash);

    if (log.isDebugEnabled()) {
      String debugMsg = String.format("Resolving execution jar name: dirname: %s, jar name: %s",
          dirName, jarPrefix);
      log.debug(debugMsg);
    }

    File[] potentialExecutionJarList;
    try {
      potentialExecutionJarList = getFilesInFolderByRegex(new File(dirName),
          jarPrefix + ".*(jar|py)");
    } catch (FileNotFoundException e) {
      throw new IllegalStateException(
          "execution jar is suppose to be in this folder, but the folder doesn't exist: "
              + dirName);
    }

    if (potentialExecutionJarList.length == 0) {
      throw new IllegalStateException("unable to find execution jar for Spark at path: "
          + userSpecifiedJarPath + "*.(jar|py)");
    } else if (potentialExecutionJarList.length > 1) {
      throw new IllegalStateException(
          "I find more than one matching instance of the execution jar at the path, don't know which one to use: "
              + userSpecifiedJarPath + "*.(jar|py)");
    }

    String resolvedJarName = potentialExecutionJarList[0].toString();
    log.info("Resolving execution jar/py name: resolvedJarName: " + resolvedJarName);
    return resolvedJarName;
  }