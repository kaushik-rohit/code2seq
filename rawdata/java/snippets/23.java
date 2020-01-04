@Nullable
  public static <T extends Enum<T>> T getEnumIfPresent(final Class<T> enumClass, final String value)
  {
    Preconditions.checkNotNull(enumClass, "enumClass");
    Preconditions.checkNotNull(value, "value");

    for (T enumValue : enumClass.getEnumConstants()) {
      if (enumValue.name().equals(value)) {
        return enumValue;
      }
    }

    return null;
  }