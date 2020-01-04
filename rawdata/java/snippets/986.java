@Bean
  public AlternateTypeRuleConvention pageableConvention(
      final TypeResolver resolver,
      final RepositoryRestConfiguration restConfiguration) {
    return new AlternateTypeRuleConvention() {

      @Override
      public int getOrder() {
        return Ordered.HIGHEST_PRECEDENCE;
      }

      @Override
      public List<AlternateTypeRule> rules() {
        return singletonList(
            newRule(resolver.resolve(Pageable.class), resolver.resolve(pageableMixin(restConfiguration)))
        );
      }
    };
  }