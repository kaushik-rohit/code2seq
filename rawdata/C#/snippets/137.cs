public byte[] GetRandomUid(int length)
        {
            lock (Generator)
            {
                byte[] uid = new byte[length];
                Generator.GetBytes(uid);
                return uid;
            }
        }