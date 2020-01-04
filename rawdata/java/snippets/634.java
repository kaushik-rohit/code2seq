public static FileBatch forFiles(List<File> files) throws IOException {
        List<String> origPaths = new ArrayList<>(files.size());
        List<byte[]> bytes = new ArrayList<>(files.size());
        for (File f : files) {
            bytes.add(FileUtils.readFileToByteArray(f));
            origPaths.add(f.toURI().toString());
        }
        return new FileBatch(bytes, origPaths);
    }