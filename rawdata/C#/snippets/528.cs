public void LockReleased(LockDefinition lockDefinition)
        {
            if (lockDefinition.Type == LockType.Contract)
            {
                System.TryGetContractLock();
            }
        }