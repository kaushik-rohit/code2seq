public bool UndoCheckoutIfUnchanged(string filePath)
        {
            try
            {
                var info = CreateProcessExecutorInfo("Diff", filePath, "/format:Brief");
                var output = ProcessExecutor.ExecuteCmd(info);

                if (output.Contains("files differ"))
                {
                    return false;
                }

                Undo(filePath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Undo Checkout If Unchanged for file " + filePath + Environment.NewLine + ex);
            }
        }