public static string ConvertBlobNameToFileName(string blobName, DateTimeOffset? snapshotTime)
        {
            string fileName = blobName;

            //replace dirctionary
            Dictionary<string, string> replaceRules = new Dictionary<string, string>()
	            {
	                {"/", "\\"}
	            };

            foreach (KeyValuePair<string, string> rule in replaceRules)
            {
                fileName = fileName.Replace(rule.Key, rule.Value);
            }

            if (snapshotTime != null)
            {
                int index = fileName.LastIndexOf('.');

                string prefix = string.Empty;
                string postfix = string.Empty;
                string timeStamp = string.Format("{0:u}", snapshotTime.Value);
                timeStamp = timeStamp.Replace(":", string.Empty).TrimEnd(new char[] { 'Z' });

                if(index == -1)
                {
                    prefix = fileName;
                    postfix = string.Empty;
                }
                else
                {
                    prefix = fileName.Substring(0, index);
                    postfix = fileName.Substring(index);
                }

                fileName = string.Format(Resources.FileNameFormatForSnapShot, prefix, timeStamp, postfix);
            }

            return fileName;
        }