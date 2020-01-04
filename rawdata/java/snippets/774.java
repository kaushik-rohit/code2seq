public static AlternateTypeRule newRule(Type original, Type alternate, int order) {
    TypeResolver resolver = new TypeResolver();
    return new AlternateTypeRule(resolver.resolve(original), resolver.resolve(alternate), order);
  }