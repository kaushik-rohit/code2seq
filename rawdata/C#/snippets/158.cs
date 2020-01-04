public static PixelariaFile LoadFileFromDisk(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            // Signature Block
            if (reader.ReadByte() != 'P' || reader.ReadByte() != 'X' || reader.ReadByte() != 'L')
            {
                return null;
            }

            // Bundle Header block
            int bundleVersion = reader.ReadInt32();
            stream.Close();

            PixelariaFile file;

            ////////
            //// Version 9 and later
            ////////
            if (bundleVersion >= 9)
            {
                file = new PixelariaFile(new Bundle("Name"), path);

                PixelariaFileLoader.Load(file);

                return file;
            }

            Bundle bundle = LoadBundleFromDisk(path);

            file = new PixelariaFile(bundle, path);
            file.PrepareBlocksWithBundle();

            return file;
        }