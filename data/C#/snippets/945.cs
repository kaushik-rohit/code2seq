public static bool IsValidQueueName(string queueName)
        {
            Regex regex = new Regex(@"^[0-9a-z]([a-z0-9]|(?<=[a-z0-9])-(?=[a-z0-9])){1,61}[0-9a-z]$");
            return regex.IsMatch(queueName);
        }