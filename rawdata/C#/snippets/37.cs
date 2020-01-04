public IReadOnlyList<ExternalLinkDefinition> Get(RepoDistSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var cachedSettings = new RepoDistSettings(null, settings.SettingsCache);
            IEnumerable<ExternalLinkDefinition> effective = _externalLinksStorage.Load(cachedSettings);

            if (settings.LowerPriority != null)
            {
                var lowerPriorityLoader = new ConfiguredLinkDefinitionsProvider(_externalLinksStorage);
                effective = effective.Union(lowerPriorityLoader.Get(settings.LowerPriority));
            }

            return effective.ToList();
        }