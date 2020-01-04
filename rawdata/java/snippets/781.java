private static void statFile(String fname) {
    try {
      Path path = Paths.get(new URI(fname));
      long size = Files.size(path);
      System.out.println(fname + ": " + size + " bytes.");
    } catch (Exception ex) {
      System.out.println(fname + ": " + ex.toString());
    }
  }