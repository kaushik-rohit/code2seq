public override void OnProcessStarted(System.Diagnostics.Process process)
        {
            Logger.Info("Recording PID of the started process:" + process.Id + ". PID file destination is " + Pidfile);
            try
            {
                System.IO.File.WriteAllText(Pidfile, process.Id.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error("Cannot update the PID file " + Pidfile, ex);
            }
        }