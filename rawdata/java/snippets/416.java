public static long timeStringAs(String str, TimeUnit unit) {
    String lower = str.toLowerCase(Locale.ROOT).trim();

    try {
      Matcher m = Pattern.compile("(-?[0-9]+)([a-z]+)?").matcher(lower);
      if (!m.matches()) {
        throw new NumberFormatException("Failed to parse time string: " + str);
      }

      long val = Long.parseLong(m.group(1));
      String suffix = m.group(2);

      // Check for invalid suffixes
      if (suffix != null && !timeSuffixes.containsKey(suffix)) {
        throw new NumberFormatException("Invalid suffix: \"" + suffix + "\"");
      }

      // If suffix is valid use that, otherwise none was provided and use the default passed
      return unit.convert(val, suffix != null ? timeSuffixes.get(suffix) : unit);
    } catch (NumberFormatException e) {
      String timeError = "Time must be specified as seconds (s), " +
              "milliseconds (ms), microseconds (us), minutes (m or min), hour (h), or day (d). " +
              "E.g. 50s, 100ms, or 250us.";

      throw new NumberFormatException(timeError + "\n" + e.getMessage());
    }
  }