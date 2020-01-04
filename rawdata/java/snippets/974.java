static TimeUnit parseTimeUnit(String key, @Nullable String value) {
    requireArgument((value != null) && !value.isEmpty(), "value of key %s omitted", key);
    @SuppressWarnings("NullAway")
    char lastChar = Character.toLowerCase(value.charAt(value.length() - 1));
    switch (lastChar) {
      case 'd':
        return TimeUnit.DAYS;
      case 'h':
        return TimeUnit.HOURS;
      case 'm':
        return TimeUnit.MINUTES;
      case 's':
        return TimeUnit.SECONDS;
      default:
        throw new IllegalArgumentException(String.format(
            "key %s invalid format; was %s, must end with one of [dDhHmMsS]", key, value));
    }
  }