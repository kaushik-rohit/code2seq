public static void proxyUserKillAllSpawnedHadoopJobs(final String logFilePath, Props jobProps,
      File tokenFile, final Logger log) {
    Properties properties = new Properties();
    properties.putAll(jobProps.getFlattened());

    try {
      if (HadoopSecureWrapperUtils.shouldProxy(properties)) {
        UserGroupInformation proxyUser =
            HadoopSecureWrapperUtils.setupProxyUser(properties,
                tokenFile.getAbsolutePath(), log);
        proxyUser.doAs(new PrivilegedExceptionAction<Void>() {
          @Override
          public Void run() throws Exception {
            HadoopJobUtils.killAllSpawnedHadoopJobs(logFilePath, log);
            return null;
          }
        });
      } else {
        HadoopJobUtils.killAllSpawnedHadoopJobs(logFilePath, log);
      }
    } catch (Throwable t) {
      log.warn("something happened while trying to kill all spawned jobs", t);
    }
  }