private Manifest getJarManifest(File container) throws IOException {
        if (container.isDirectory()) {
            return null;
        }
        JarFile jarFile = (JarFile) jarFiles.get(container);
        if (jarFile == null) {
            return null;
        }
        return jarFile.getManifest();
    }