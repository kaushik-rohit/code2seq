@Override
    public void renameTo(String newName) throws IOException {
        File oldBuildDir = getBuildDir();
        super.renameTo(newName);
        File newBuildDir = getBuildDir();
        if (oldBuildDir.isDirectory() && !newBuildDir.isDirectory()) {
            if (!newBuildDir.getParentFile().isDirectory()) {
                newBuildDir.getParentFile().mkdirs();
            }
            if (!oldBuildDir.renameTo(newBuildDir)) {
                throw new IOException("failed to rename " + oldBuildDir + " to " + newBuildDir);
            }
        }
    }