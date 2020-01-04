public void WriteInteger(long v, int numbytes)
        {
            long val = v;

            Debug.Assert(numbytes > 0 && numbytes < 9);

            for (int x = 0; x < numbytes; x++)
            {
                tempBuffer[x] = (byte)(val & 0xff);
                val >>= 8;
            }
            Write(tempBuffer, 0, numbytes);
        }