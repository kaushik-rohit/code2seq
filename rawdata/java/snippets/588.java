public static URLClassLoader getClassLoaderForExtension(File extension, boolean useExtensionClassloaderFirst)
  {
    return loadersMap.computeIfAbsent(
        extension,
        theExtension -> makeClassLoaderForExtension(theExtension, useExtensionClassloaderFirst)
    );
  }