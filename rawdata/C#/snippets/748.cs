public static bool CheckServerAdminToken(string AServerAdminToken)
        {
            string TokenFilename = TAppSettingsManager.GetValue("Server.PathTemp") +
                                   Path.DirectorySeparatorChar + "ServerAdminToken" + AServerAdminToken + ".txt";

            if (File.Exists(TokenFilename))
            {
                using (StreamReader sr = new StreamReader(TokenFilename))
                {
                    string content = sr.ReadToEnd();
                    sr.Close();

                    if (content.Trim() == AServerAdminToken)
                    {
                        return true;
                    }
                }
            }
            else
            {
                TLogging.Log("cannot find security token file " + TokenFilename);
            }

            return false;
        }