public static String getPropertyDiff(Props oldProps, Props newProps) {

    final StringBuilder builder = new StringBuilder("");

    // oldProps can not be null during the below comparison process.
    if (oldProps == null) {
      oldProps = new Props();
    }

    if (newProps == null) {
      newProps = new Props();
    }

    final MapDifference<String, String> md =
        Maps.difference(toStringMap(oldProps, false), toStringMap(newProps, false));

    final Map<String, String> newlyCreatedProperty = md.entriesOnlyOnRight();
    if (newlyCreatedProperty != null && newlyCreatedProperty.size() > 0) {
      builder.append("Newly created Properties: ");
      newlyCreatedProperty.forEach((k, v) -> {
        builder.append("[ " + k + ", " + v + "], ");
      });
      builder.append("\n");
    }

    final Map<String, String> deletedProperty = md.entriesOnlyOnLeft();
    if (deletedProperty != null && deletedProperty.size() > 0) {
      builder.append("Deleted Properties: ");
      deletedProperty.forEach((k, v) -> {
        builder.append("[ " + k + ", " + v + "], ");
      });
      builder.append("\n");
    }

    final Map<String, MapDifference.ValueDifference<String>> diffProperties = md.entriesDiffering();
    if (diffProperties != null && diffProperties.size() > 0) {
      builder.append("Modified Properties: ");
      diffProperties.forEach((k, v) -> {
        builder.append("[ " + k + ", " + v.leftValue() + "-->" + v.rightValue() + "], ");
      });
    }
    return builder.toString();
  }