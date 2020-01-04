public static long copyToFileAndClose(InputStream is, File file) throws IOException
  {
    file.getParentFile().mkdirs();
    try (OutputStream os = new BufferedOutputStream(new FileOutputStream(file))) {
      final long result = ByteStreams.copy(is, os);
      // Workarround for http://hg.openjdk.java.net/jdk8/jdk8/jdk/rev/759aa847dcaf
      os.flush();
      return result;
    }
    finally {
      is.close();
    }
  }