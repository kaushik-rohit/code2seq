public static bool IsValidQueuePrefix(string queuePrefix)
        {
            if (queuePrefix.Length > 0 && queuePrefix.Length < 3)
            {
                queuePrefix = queuePrefix + "abc";
            };
            
            if(queuePrefix.EndsWith("-"))
            {
                queuePrefix += "a";
            }

            return IsValidQueueName(queuePrefix);
        }