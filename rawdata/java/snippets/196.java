public static int mode(File f) throws PosixException {
        if(Functions.isWindows())   return -1;
        try {
            if (Util.NATIVE_CHMOD_MODE) {
                return PosixAPI.jnr().stat(f.getPath()).mode();
            } else {
                return Util.permissionsToMode(Files.getPosixFilePermissions(fileToPath(f)));
            }
        } catch (IOException cause) {
            PosixException e = new PosixException("Unable to get file permissions", null);
            e.initCause(cause);
            throw e;
        }
    }