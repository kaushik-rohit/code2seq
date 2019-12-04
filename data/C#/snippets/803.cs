public override void OnWrapperStarted()
        {
            // Read PID file from the disk
            int pid;
            if (System.IO.File.Exists(Pidfile)) {
                string pidstring;
                try
                {
                    pidstring = System.IO.File.ReadAllText(Pidfile);
                }
                catch (Exception ex)
                {
                    Logger.Error("Cannot read PID file from " + Pidfile, ex);
                    return;
                }
                try
                {
                    pid = Int32.Parse(pidstring);
                }
                catch (FormatException e)
                {
                    Logger.Error("Invalid PID file number in '" + Pidfile + "'. The runaway process won't be checked", e);
                    return;
                }
            }
            else
            {
                Logger.Warn("The requested PID file '" + Pidfile + "' does not exist. The runaway process won't be checked");
                return;
            }

            // Now check the process
            Logger.DebugFormat("Checking the potentially runaway process with PID={0}", pid);
            Process proc;
            try
            {
                proc = Process.GetProcessById(pid);
            }
            catch (ArgumentException ex)
            {
                Logger.Debug("No runaway process with PID=" + pid + ". The process has been already stopped.");
                return;
            }

            // Ensure the process references the service
            String affiliatedServiceId;
            // TODO: This method is not ideal since it works only for vars explicitly mentioned in the start info
            // No Windows 10- compatible solution for EnvVars retrieval, see https://blog.gapotchenko.com/eazfuscator.net/reading-environment-variables
            StringDictionary previousProcessEnvVars = proc.StartInfo.EnvironmentVariables;
            String expectedEnvVarName = WinSWSystem.ENVVAR_NAME_SERVICE_ID;
            if (previousProcessEnvVars.ContainsKey(expectedEnvVarName))
            {
                // StringDictionary is case-insensitive, hence it will fetch variable definitions in any case
                affiliatedServiceId = previousProcessEnvVars[expectedEnvVarName];
            }
            else if (CheckWinSWEnvironmentVariable)
            {
                Logger.Warn("The process " + pid + " has no " + expectedEnvVarName + " environment variable defined. " 
                    + "The process has not been started by WinSW, hence it won't be terminated.");
                if (Logger.IsDebugEnabled) {
                    //TODO replace by String.Join() in .NET 4
                    String[] keys = new String[previousProcessEnvVars.Count];
                    previousProcessEnvVars.Keys.CopyTo(keys, 0);
                    Logger.DebugFormat("Env vars of the process with PID={0}: {1}", new Object[] {pid, String.Join(",", keys)});
                }
                return;
            }
            else
            {
                // We just skip this check
                affiliatedServiceId = null;
            }

            // Check the service ID value
            if (CheckWinSWEnvironmentVariable && !ServiceId.Equals(affiliatedServiceId))
            {
                Logger.Warn("The process " + pid + " has been started by Windows service with ID='" + affiliatedServiceId + "'. "
                    + "It is another service (current service id is '" + ServiceId + "'), hence the process won't be terminated.");
                return;
            }

            // Kill the runaway process
            StringBuilder bldr = new StringBuilder("Stopping the runaway process (pid=");
            bldr.Append(pid);
            bldr.Append(") and its children. Environment was ");
            if (!CheckWinSWEnvironmentVariable) {
                bldr.Append("not ");
            }
            bldr.Append("checked, affiliated service ID: ");
            bldr.Append(affiliatedServiceId != null ? affiliatedServiceId : "undefined");
            bldr.Append(", process to kill: ");
            bldr.Append(proc);

            Logger.Warn(bldr.ToString());
            ProcessHelper.StopProcessAndChildren(pid, this.StopTimeout, this.StopParentProcessFirst);
        }