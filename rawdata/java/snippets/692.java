private static Schema schema(int version, String type) {
    Class<? extends Schema> clz = schemaClass(version, type);
    if (clz == null) clz = schemaClass(EXPERIMENTAL_VERSION, type);

    if (clz == null)
      throw new H2ONotFoundArgumentException("Failed to find schema for version: " + version + " and type: " + type,
          "Failed to find schema for version: " + version + " and type: " + type + "\n" +
          "Did you forget to add an entry into META-INF/services/water.api.Schema?");
    return Schema.newInstance(clz);
  }