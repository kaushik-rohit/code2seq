public string Checkout(params string[] fileNames)
        {
            if (fileNames == null || fileNames.Length == 0)
            {
                return "No Files Given";
            }

            var fileNamesToCheckoutBatches = fileNames.Where(f => File.GetAttributes(f).HasFlag(FileAttributes.ReadOnly))
                                                      .BatchLessThanMaxLength(MaxCommandLength, 
                                                                              "Filename \"{0}\" is longer than the max length {1}.", 
                                                                              3 // 1 for each quote, and one more for the space between.
                                                                              );

            var output = new StringBuilder();
            foreach (var batch in fileNamesToCheckoutBatches)
            {
                try
                {
                    var files = string.Join(" ", batch.Select(WrapPathInQuotes));
                    var info = CreateProcessExecutorInfo("checkout", null, files, Directory.GetParent(fileNames.First()).FullName);
                    output.AppendLine(ProcessExecutor.ExecuteCmd(info));
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to check out files " + string.Join(", ", batch) + Environment.NewLine + ex);
                }
            }

            foreach (var file in fileNamesToCheckoutBatches.SelectMany(v => v))
            {
                if (File.GetAttributes(file).HasFlag(FileAttributes.ReadOnly))
                {
                    throw new Exception("File \"" + file + "\" is read only even though it should have been checked out, please checkout the file before running.  Output: " + output);
                }
            }
            return output.ToString();
        }