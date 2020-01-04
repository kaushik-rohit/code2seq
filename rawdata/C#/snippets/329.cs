public static PubsubService AuthenticateServiceAccount(string serviceAccountEmail, string serviceAccountCredentialFilePath, string[] scopes)
		{
            try
            {
                if (string.IsNullOrEmpty(serviceAccountCredentialFilePath))
                    throw new Exception("Path to the service account credentials file is required.");
                if (!File.Exists(serviceAccountCredentialFilePath))
                    throw new Exception("The service account credentials file does not exist at: " + serviceAccountCredentialFilePath);
                if (string.IsNullOrEmpty(serviceAccountEmail))
                    throw new Exception("ServiceAccountEmail is required.");                

                // For Json file
                if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".json")
                {
                    GoogleCredential credential;
                    using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
                    {
                        credential = GoogleCredential.FromStream(stream)
                             .CreateScoped(scopes);
                    }

                    // Create the  Analytics service.
                    return new PubsubService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Pubsub Service account Authentication Sample",
                    });
                }
                else if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".p12")
                {   // If its a P12 file

                    var certificate = new X509Certificate2(serviceAccountCredentialFilePath, "notasecret", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                    var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(certificate));

                    // Create the  Pubsub service.
                    return new PubsubService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Pubsub Authentication Sample",
                    });
                }
                else
                {
                    throw new Exception("Unsupported Service accounts credentials.");
                }

            }
            catch (Exception ex)
            {                
                throw new Exception("CreateServiceAccountPubsubFailed", ex);
            }
        }