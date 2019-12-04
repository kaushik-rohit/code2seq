public static CompositionDependency Oversupplied(CompositionContract contract, IEnumerable<ExportDescriptorPromise> targets, object site)
        {
            Requires.NotNull(targets, nameof(targets));
            Requires.NotNull(site, nameof(site));
            Requires.NotNull(contract, nameof(contract));

            return new CompositionDependency(contract, targets, site);
        }