public static async Task InitializeWithDefaultsAsync(this IDocumentStore documentStore,
            IEnumerable<IEnumerable> seedData = null,
            ICollection<Type> indexesToExecute = null,
            ICollection<Type> assembliesToScanForIndexes = null,
            bool areDocumentStoreErrorsTreatedAsWarnings = false)
        {
            // Default initialization;
            documentStore.Initialize();

            // Static indexes or ResultTransformers.
            CreateIndexes(indexesToExecute, assembliesToScanForIndexes, documentStore);

            // Create our Seed Data (if provided).
            if (seedData != null)
            {
                await CreateSeedDataAsync(seedData, documentStore);
            }

            // Now lets check to make sure there are now errors.
            documentStore.AssertDocumentStoreErrors(areDocumentStoreErrorsTreatedAsWarnings);

            // Display any statistics.
            ReportOnInitializedStatistics(documentStore);
        }