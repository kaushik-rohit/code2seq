public static void AssertDocumentStoreErrors(this IDocumentStore documentStore,
            bool areDocumentStoreErrorsTreatedAsWarnings = false)
        {
            if (documentStore == null)
            {
                throw new ArgumentNullException("documentStore");
            }

            var errors = documentStore.DatabaseCommands.GetStatistics().Errors;
            if (errors == null ||
                errors.Length <= 0)
            {
                return;
            }

            // We have some Errors. NOT. GOOD. :(
            var errorMessage = "No server errors supplied.";
            foreach (var serverError in errors)
            {
                errorMessage = string.Format("Document: {0}; Index: {1}; Error: {2}",
                    string.IsNullOrEmpty(serverError.Document)
                        ? "No Document Id"
                        : serverError.Document,
                    string.IsNullOrEmpty(serverError.IndexName)
                        ? "No Index"
                        : serverError.IndexName,
                    string.IsNullOrEmpty(serverError.Error)
                        ? "No Error message .. err??"
                        : serverError.Error);
            }

            if (areDocumentStoreErrorsTreatedAsWarnings)
            {
                Trace.TraceWarning(errorMessage);
            }
            else
            {
                Trace.TraceError(errorMessage);
                throw new InvalidOperationException(string.Format(
                    "### DocumentStore has some errors ###. BLECH!. {0}",
                    string.IsNullOrEmpty(errorMessage)
                        ? string.Empty
                        : "Errors: " + errorMessage));
            }
        }