public static NodeBean setPropsInNodeBean(final String path, final File flowFile,
      final Props prop) {
    final NodeBeanLoader loader = new NodeBeanLoader();
    try {
      final NodeBean nodeBean = loader.load(flowFile);
      final String[] pathList = path.split(Constants.PATH_DELIMITER);
      if (overridePropsInNodeBean(nodeBean, pathList, 0, prop)) {
        return nodeBean;
      } else {
        logger.error("Error setting props for " + path);
      }
    } catch (final Exception e) {
      logger.error("Failed to set props, error loading flow YAML file " + flowFile);
    }
    return null;
  }