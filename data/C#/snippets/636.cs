static int GetNextRandom(int maxValue)
        {
#if NET452
            var bytes = new byte[4];
            lock (randomServiceLock)
            {
                RandomService.GetBytes(bytes);
            }
            return (int)Math.Round(((double)BitConverter.ToUInt32(bytes, 0) / uint.MaxValue) * (maxValue - 1));
#else
            return RandomService.Next(maxValue);
#endif
        }