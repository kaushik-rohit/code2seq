public void LockAcquire(LockDefinition lockDefinition)
        {
            if (lockDefinition.Type == LockType.Contract && lockDefinition.PlayerName == SettingsSystem.CurrentSettings.PlayerName)
            {
                ContractSystem.generateContractIterations = ShareContractsSystem.Singleton.DefaultContractGenerateIterations;
            }
        }