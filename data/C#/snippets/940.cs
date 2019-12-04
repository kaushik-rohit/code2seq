public static bool IsValidContainerName(string containerName)
        {
            Regex regex = new Regex(@"^\$root$|^\$logs$|^[a-z0-9]([a-z0-9]|(?<=[a-z0-9])-(?=[a-z0-9])){2,62}$");
            return regex.IsMatch(containerName);
        }