public void Undo(string filePath)
        {
            try
            {
                var info = CreateProcessExecutorInfo("undo", filePath, "/noprompt");

                ProcessExecutor.ExecuteCmd(info);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Undo Checkout for file " + filePath + Environment.NewLine + ex);
            }
        }