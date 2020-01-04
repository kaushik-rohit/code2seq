public string GetRandomUidHex(int length)
        {
            lock (Generator)
            {
                byte[] uid = new byte[length];
                Generator.GetBytes(uid);
                return StringUtil.ByteArrayToHexViaLookup32Unsafe(uid);
            }
        }