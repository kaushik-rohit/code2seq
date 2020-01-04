public static void downloadAndExtract(String name, URL url, File f, File extractToDir, String targetMD5, int maxTries) throws IOException {
        downloadAndExtract(0, maxTries, name, url, f, extractToDir, targetMD5);
    }