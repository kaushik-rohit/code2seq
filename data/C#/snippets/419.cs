public string Get(bool overwrite, params string[] fileNames)
        {
            if (fileNames == null || fileNames.Length == 0)
            {
                return "No Files Given";
            }

            var fileNameBatches = fileNames.BatchLessThanMaxLength(MaxCommandLength,
                                                      "Filename \"{0}\" is longer than the max length {1}.",
                                                      3 // 1 for each quote, and one more for the space between.
                                                      );

            var output = new StringBuilder();
            foreach (var batch in fileNameBatches)
            {
                try
                {
                    var files = string.Join(" ", batch.Select(WrapPathInQuotes));
                    var info = CreateProcessExecutorInfo("get", null, files + (overwrite ? " /overwrite": ""), Directory.GetParent(fileNames.First()).FullName);
                    output.AppendLine(ProcessExecutor.ExecuteCmd(info));
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to get files " + string.Join(", ", batch) + Environment.NewLine + ex);
                }
            }
            return output.ToString();
        }