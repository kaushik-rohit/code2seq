public static RepoCleanerConfig Load(string fileName, string outputDir)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string jsonContents = sr.ReadToEnd();
                
                var configObj = JsonConvert.DeserializeObject<Dictionary<string, RepoConfigEntry>>(jsonContents);
                // Update name from Dictionary key
                foreach (var pair in configObj)
                {
                    pair.Value.Name = pair.Key;

                    // Set destination if not set per-repo
                    if (string.IsNullOrEmpty(pair.Value.DestinationPath))
                    {
                        pair.Value.DestinationPath = outputDir;
                    }
                }

                RepoCleanerConfig config = new RepoCleanerConfig()
                {
                    Entries = configObj.Values
                };
                
                return config;
            }
            
        }