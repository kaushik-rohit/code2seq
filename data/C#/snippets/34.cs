public Builder WithDatabaseAdapterSetting(string configKey, string configValue)
            {
                this.databaseAdapterConfiguration[configKey] = configValue;
                return this;
            }