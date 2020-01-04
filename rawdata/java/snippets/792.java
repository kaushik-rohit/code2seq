List<String> buildClassPath(String appClassPath) throws IOException {
    String sparkHome = getSparkHome();

    Set<String> cp = new LinkedHashSet<>();
    addToClassPath(cp, appClassPath);

    addToClassPath(cp, getConfDir());

    boolean prependClasses = !isEmpty(getenv("SPARK_PREPEND_CLASSES"));
    boolean isTesting = "1".equals(getenv("SPARK_TESTING"));
    if (prependClasses || isTesting) {
      String scala = getScalaVersion();
      List<String> projects = Arrays.asList(
        "common/kvstore",
        "common/network-common",
        "common/network-shuffle",
        "common/network-yarn",
        "common/sketch",
        "common/tags",
        "common/unsafe",
        "core",
        "examples",
        "graphx",
        "launcher",
        "mllib",
        "repl",
        "resource-managers/mesos",
        "resource-managers/yarn",
        "sql/catalyst",
        "sql/core",
        "sql/hive",
        "sql/hive-thriftserver",
        "streaming"
      );
      if (prependClasses) {
        if (!isTesting) {
          System.err.println(
            "NOTE: SPARK_PREPEND_CLASSES is set, placing locally compiled Spark classes ahead of " +
            "assembly.");
        }
        for (String project : projects) {
          addToClassPath(cp, String.format("%s/%s/target/scala-%s/classes", sparkHome, project,
            scala));
        }
      }
      if (isTesting) {
        for (String project : projects) {
          addToClassPath(cp, String.format("%s/%s/target/scala-%s/test-classes", sparkHome,
            project, scala));
        }
      }

      // Add this path to include jars that are shaded in the final deliverable created during
      // the maven build. These jars are copied to this directory during the build.
      addToClassPath(cp, String.format("%s/core/target/jars/*", sparkHome));
      addToClassPath(cp, String.format("%s/mllib/target/jars/*", sparkHome));
    }

    // Add Spark jars to the classpath. For the testing case, we rely on the test code to set and
    // propagate the test classpath appropriately. For normal invocation, look for the jars
    // directory under SPARK_HOME.
    boolean isTestingSql = "1".equals(getenv("SPARK_SQL_TESTING"));
    String jarsDir = findJarsDir(getSparkHome(), getScalaVersion(), !isTesting && !isTestingSql);
    if (jarsDir != null) {
      addToClassPath(cp, join(File.separator, jarsDir, "*"));
    }

    addToClassPath(cp, getenv("HADOOP_CONF_DIR"));
    addToClassPath(cp, getenv("YARN_CONF_DIR"));
    addToClassPath(cp, getenv("SPARK_DIST_CLASSPATH"));
    return new ArrayList<>(cp);
  }