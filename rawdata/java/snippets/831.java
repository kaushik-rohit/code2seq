public static UserGroupInformation getProxiedUser(final Properties prop,
      final Logger log, final Configuration conf) throws IOException {
    final String toProxy = verifySecureProperty(prop, JobProperties.USER_TO_PROXY, log);
    final UserGroupInformation user = getProxiedUser(toProxy, prop, log, conf);
    if (user == null) {
      throw new IOException(
          "Proxy as any user in unsecured grid is not supported!"
              + prop.toString());
    }
    log.info("created proxy user for " + user.getUserName() + user.toString());
    return user;
  }