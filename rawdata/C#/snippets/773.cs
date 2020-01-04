public virtual bool Run(IModule module, string macroName, string arguments)
        {
            if (ToEmme == null || Emme == null) return false;
            var externFile = Path.GetFullPath(Path.Combine(ProjectFile, "ExternalCommand.lock"));
            lock (this)
            {
                if (!File.Exists(externFile))
                {
                    File.Create(externFile).Close();
                }
                StringBuilder builder = new StringBuilder();
                builder.Append("~<" + macroName);
                if (!string.IsNullOrEmpty(arguments))
                {
                    builder.Append(' ');
                    builder.Append(arguments);
                }
                var timeToFail = FailTimer;
                var startTime = DateTime.Now;
                ToEmme.WriteLine(builder.ToString());
                while (File.Exists(externFile))
                {
                    if (Emme == null || Emme.HasExited)
                    {
                        return false;
                    }
                    var currentTime = DateTime.Now;
                    if ((currentTime - startTime) > TimeSpan.FromMinutes(timeToFail))
                    {
                        return false;
                    }
                    Thread.Sleep(100);
                }
            }
            return true;
        }