public bool AreDifferent(string sourcePath, string diffPath)
        {
            try
            {
                var info = CreateProcessExecutorInfo("Diff", sourcePath, WrapPathInQuotes(diffPath) + " /format:Brief");
                var output = ProcessExecutor.ExecuteCmd(info);

                return output.Contains("files differ");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to determine if \"{sourcePath}\" is different than \"{diffPath}" + sourcePath + Environment.NewLine + ex);
            }
        }