private void HandleStorageMessage(StorageHeldItemsMessage storagestate)
        {
            StoredEntities = new Dictionary<EntityUid, int>(storagestate.StoredEntities);
            StorageSizeUsed = storagestate.StorageSizeUsed;
            StorageCapacityMax = storagestate.StorageSizeMax;
            Window.BuildEntityList();
        }