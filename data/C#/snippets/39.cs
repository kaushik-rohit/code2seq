public BotConfiguration Build()
            {
                this.config.BackendConfiguration = new ReadOnlyDictionary<string, string>(
                    this.backendConfiguration);

                this.config.DatabaseAdapterConfiguration = new ReadOnlyDictionary<string, string>(
                    this.databaseAdapterConfiguration);

                return this.config;
            }