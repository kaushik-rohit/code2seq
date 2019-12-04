public static bool IsValidBlobName(string blobName)
        {
            int minLength = 0;
            int maxLength = 1024;

            if (blobName.Length > minLength && blobName.Length <= maxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }