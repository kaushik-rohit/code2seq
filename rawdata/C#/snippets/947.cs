public static bool IsValidFileName(string fileName)
        {
            //http://msdn.microsoft.com/en-us/library/windows/desktop/aa365247(v=vs.85).aspx#maxpath

            if (string.IsNullOrEmpty(fileName) || fileName.Length > WindowsMaxFileNameLength)
            {
                return false;
            }
            else if (fileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            {
                return false;
            }
            else
            {
                string realName = Path.GetFileNameWithoutExtension(fileName);
                //http://en.wikipedia.org/wiki/Filename
                //In Windows and DOS utilities, some words might also be reserved and can not be used as filenames.
                //However, "CLOCK$", "COM0", "LPT0" are not forbidden name since they can be used as file name in command line prompt.
                string[] forbiddenList = { "CON", "PRN", "AUX", "NUL", 
                    "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                    "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
                bool forbidden = forbiddenList.Contains(realName);
                return !forbidden;
            }
        }