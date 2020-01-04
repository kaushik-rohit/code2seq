public static Frame LoadFrameFromStream(Stream stream, Animation owningAnimation, int version)
        {
            BinaryReader reader = new BinaryReader(stream);

            // Read the size of the frame texture
            long textSize = reader.ReadInt64();

            Frame frame = new Frame(owningAnimation, owningAnimation.Width, owningAnimation.Height, false);

            MemoryStream memStream = new MemoryStream();

            long pos = stream.Position;

            byte[] buff = new byte[textSize];
            stream.Read(buff, 0, buff.Length);
            stream.Position = pos + textSize;

            memStream.Write(buff, 0, buff.Length);

            Image img = Image.FromStream(memStream);

            // The Bitmap constructor is used here because images loaded from streams are read-only and cannot be directly edited
            Bitmap bitmap = new Bitmap(img);

            img.Dispose();

            if (version >= 8)
            {
                frame.ID = reader.ReadInt32();
            }

            // Get the hash now
            byte[] hash;

            if (version >= 6)
            {
                int length = reader.ReadInt32();
                hash = new byte[length];
                stream.Read(hash, 0, length);
            }
            else
            {
                memStream.Position = 0;
                hash = ImageUtilities.GetHashForStream(memStream);
            }

            memStream.Dispose();

            frame.SetFrameBitmap(bitmap, false);
            frame.SetHash(hash);

            return frame;
        }