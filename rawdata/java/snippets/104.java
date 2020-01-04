private static Severity severityFor(Level level) {
    switch (level.toInt()) {
        // TRACE
      case 5000:
        return Severity.DEBUG;
        // DEBUG
      case 10000:
        return Severity.DEBUG;
        // INFO
      case 20000:
        return Severity.INFO;
        // WARNING
      case 30000:
        return Severity.WARNING;
        // ERROR
      case 40000:
        return Severity.ERROR;
      default:
        return Severity.DEFAULT;
    }
  }