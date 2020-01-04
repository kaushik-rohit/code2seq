private void validateDepDefinitionUniqueness(final List<FlowTriggerDependency> dependencies) {
    final Set<String> seen = new HashSet<>();
    for (final FlowTriggerDependency dep : dependencies) {
      final Map<String, String> props = dep.getProps();
      // set.add() returns false when there exists duplicate
      Preconditions.checkArgument(seen.add(dep.getType() + ":" + props.toString()), String.format
          ("duplicate dependency config %s found, dependency config should be unique",
              dep.getName()));
    }
  }