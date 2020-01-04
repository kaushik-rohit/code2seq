protected virtual void SetEnvironment (Process process) {
            if (Ssh != null && !Ssh.Exists) {
                FileInfo tempLookup = DeriveFullPathFromEnv(PathVariable, Ssh.Name);
                if (null == tempLookup) {
                    tempLookup = DeriveFullPathFromEnv(PathVariable, Ssh.Name + ".exe");
                } 

                if (null != tempLookup) {
                    Ssh = tempLookup;
                }
            }
            if (Ssh != null) {
                try {
                    process.StartInfo.EnvironmentVariables.Add(SshEnv, Ssh.FullName);
                } catch (System.ArgumentException e) {
                    Logger.Warn("Possibility cvs_rsh key has already been added.", e);
                }
            }
            if (null != this.PassFile) {
                if (process.StartInfo.EnvironmentVariables.ContainsKey(CvsPassFileVariable)) {
                    process.StartInfo.EnvironmentVariables[CvsPassFileVariable] = this.PassFile.FullName;
                } else {
                    process.StartInfo.EnvironmentVariables.Add(CvsPassFileVariable, PassFile.FullName);
                }
            }
            Log(Level.Verbose, "Using ssh binary: {0}", process.StartInfo.EnvironmentVariables[SshEnv]);
            Log(Level.Verbose, "Using .cvspass file: {0}", process.StartInfo.EnvironmentVariables[CvsPassFileVariable]);
        }