public void Add(string filePath)
        {
            try
            {
                var info = CreateProcessExecutorInfo("add", filePath);
                ProcessExecutor.ExecuteCmd(info);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Add the file " + filePath + Environment.NewLine + ex);
            }
        }