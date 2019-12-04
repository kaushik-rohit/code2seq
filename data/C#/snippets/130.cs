public static CompositionDependency Missing(CompositionContract contract, object site)
        {
            Requires.NotNull(contract, nameof(contract));
            Requires.NotNull(site, nameof(site));

            return new CompositionDependency(contract, site);
        }