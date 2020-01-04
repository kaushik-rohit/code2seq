public static Field getField(String fieldName, Class<?> clazz) {
    Field field = null;
    try {
      field = clazz.getDeclaredField(fieldName);
    } catch (SecurityException e) {
      throw new ActivitiException("not allowed to access field " + field + " on class " + clazz.getCanonicalName());
    } catch (NoSuchFieldException e) {
      // for some reason getDeclaredFields doesn't search superclasses
      // (which getFields() does ... but that gives only public fields)
      Class<?> superClass = clazz.getSuperclass();
      if (superClass != null) {
        return getField(fieldName, superClass);
      }
    }
    return field;
  }