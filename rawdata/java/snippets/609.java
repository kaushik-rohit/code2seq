private static String mergePaths(String path1, String path2)
  {
    return path1 + (path1.endsWith(Path.SEPARATOR) ? "" : Path.SEPARATOR) + path2;
  }