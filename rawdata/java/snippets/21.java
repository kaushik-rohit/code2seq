public static JavaRDD<String> listPaths(JavaSparkContext sc, String path, boolean recursive) throws IOException {
        //NativeImageLoader.ALLOWED_FORMATS
        return listPaths(sc, path, recursive, (Set<String>)null);
    }