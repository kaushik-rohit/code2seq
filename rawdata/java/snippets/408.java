private static void printAndLogVersion(String[] arguments) {
    Log.init(ARGS.log_level, ARGS.quiet);
    Log.info("----- H2O started " + (ARGS.client?"(client)":"") + " -----");
    Log.info("Build git branch: " + ABV.branchName());
    Log.info("Build git hash: " + ABV.lastCommitHash());
    Log.info("Build git describe: " + ABV.describe());
    Log.info("Build project version: " + ABV.projectVersion());
    Log.info("Build age: " + PrettyPrint.toAge(ABV.compiledOnDate(), new Date()));
    Log.info("Built by: '" + ABV.compiledBy() + "'");
    Log.info("Built on: '" + ABV.compiledOn() + "'");

    if (ABV.isTooOld()) {
      Log.warn("\n*** Your H2O version is too old! Please download the latest version from http://h2o.ai/download/ ***");
      Log.warn("");
    }

    Log.info("Found H2O Core extensions: " + extManager.getCoreExtensions());
    Log.info("Processed H2O arguments: ", Arrays.toString(arguments));

    Runtime runtime = Runtime.getRuntime();
    Log.info("Java availableProcessors: " + runtime.availableProcessors());
    Log.info("Java heap totalMemory: " + PrettyPrint.bytes(runtime.totalMemory()));
    Log.info("Java heap maxMemory: " + PrettyPrint.bytes(runtime.maxMemory()));
    Log.info("Java version: Java "+System.getProperty("java.version")+" (from "+System.getProperty("java.vendor")+")");
    List<String> launchStrings = ManagementFactory.getRuntimeMXBean().getInputArguments();
    Log.info("JVM launch parameters: "+launchStrings);
    Log.info("OS version: "+System.getProperty("os.name")+" "+System.getProperty("os.version")+" ("+System.getProperty("os.arch")+")");
    long totalMemory = OSUtils.getTotalPhysicalMemory();
    Log.info ("Machine physical memory: " + (totalMemory==-1 ? "NA" : PrettyPrint.bytes(totalMemory)));
  }