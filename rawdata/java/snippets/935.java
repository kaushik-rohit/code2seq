public static void createFileBatchesSpark(JavaRDD<String> filePaths, final String rootOutputDir, final int batchSize, JavaSparkContext sc) {
        createFileBatchesSpark(filePaths, rootOutputDir, batchSize, sc.hadoopConfiguration());
    }