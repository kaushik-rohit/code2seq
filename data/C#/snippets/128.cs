public static CompositionDependency Satisfied(CompositionContract contract, ExportDescriptorPromise target, bool isPrerequisite, object site)
        {
            Requires.NotNull(target, nameof(target));
            Requires.NotNull(site, nameof(site));
            Requires.NotNull(contract, nameof(contract));

            return new CompositionDependency(contract, target, isPrerequisite, site);
        }