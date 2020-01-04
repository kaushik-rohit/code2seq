public static bool IsValidContainerPrefix(string containerPrefix)
        {
            if (containerPrefix.StartsWith("$"))
            {
                string root = "$root";
                string logs = "$logs";

                if (root.IndexOf(containerPrefix) == 0 || logs.IndexOf(containerPrefix) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (containerPrefix.Length > 0 && containerPrefix.Length < 3)
                {
                    containerPrefix = containerPrefix + "abc";
                };

                if (containerPrefix.EndsWith("-"))
                { 
                    containerPrefix += "a";
                }

                return IsValidContainerName(containerPrefix);
            }
        }