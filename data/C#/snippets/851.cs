public string MyBinaries()
        {
            ThrowIfNotSetup();
            // The exceptation is that scripts calling this are included
            // in a project in the solution and have already been deployed
            // to a binaries folder

            foreach (var configuration in new string[] {"debug", "release"})
            {
                var configurationIndex = _workingDir.IndexOf(configuration, StringComparison.CurrentCultureIgnoreCase);
                if (configurationIndex != -1)
                {
                    return _workingDir.Substring(0, configurationIndex + configuration.Length);
                }
            }

            throw new Exception("Couldn't find binaries. Are you running from the binaries directory?");
        }