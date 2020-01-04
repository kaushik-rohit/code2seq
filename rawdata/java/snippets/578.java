@Override
  public SparkAppHandle startApplication(SparkAppHandle.Listener... listeners) throws IOException {
    LauncherServer server = LauncherServer.getOrCreateServer();
    ChildProcAppHandle handle = new ChildProcAppHandle(server);
    for (SparkAppHandle.Listener l : listeners) {
      handle.addListener(l);
    }

    String secret = server.registerHandle(handle);

    String loggerName = getLoggerName();
    ProcessBuilder pb = createBuilder();

    boolean outputToLog = outputStream == null;
    boolean errorToLog = !redirectErrorStream && errorStream == null;

    // Only setup stderr + stdout to logger redirection if user has not otherwise configured output
    // redirection.
    if (loggerName == null && (outputToLog || errorToLog)) {
      String appName;
      if (builder.appName != null) {
        appName = builder.appName;
      } else if (builder.mainClass != null) {
        int dot = builder.mainClass.lastIndexOf(".");
        if (dot >= 0 && dot < builder.mainClass.length() - 1) {
          appName = builder.mainClass.substring(dot + 1, builder.mainClass.length());
        } else {
          appName = builder.mainClass;
        }
      } else if (builder.appResource != null) {
        appName = new File(builder.appResource).getName();
      } else {
        appName = String.valueOf(COUNTER.incrementAndGet());
      }
      String loggerPrefix = getClass().getPackage().getName();
      loggerName = String.format("%s.app.%s", loggerPrefix, appName);
    }

    if (outputToLog && errorToLog) {
      pb.redirectErrorStream(true);
    }

    pb.environment().put(LauncherProtocol.ENV_LAUNCHER_PORT, String.valueOf(server.getPort()));
    pb.environment().put(LauncherProtocol.ENV_LAUNCHER_SECRET, secret);
    try {
      Process child = pb.start();
      InputStream logStream = null;
      if (loggerName != null) {
        logStream = outputToLog ? child.getInputStream() : child.getErrorStream();
      }
      handle.setChildProc(child, loggerName, logStream);
    } catch (IOException ioe) {
      handle.kill();
      throw ioe;
    }

    return handle;
  }