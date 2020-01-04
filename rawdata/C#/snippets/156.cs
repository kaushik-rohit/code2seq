public static Bundle LoadBundleFromDisk(string path)
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
            string bundleName = reader.ReadString();
            string bundlePath = "";

            // New pixelaria file format
            if (bundleVersion >= 9)
            {
                stream.Close();

                return LoadFileFromDisk(path).LoadedBundle;
            }

            ////////
            //// Legacy file formats
            ////////

            if (bundleVersion >= 3)
            {
                bundlePath = reader.ReadString();
            }

            Bundle bundle = new Bundle(bundleName) { ExportPath = bundlePath };

            // Animation block
            int animCount = reader.ReadInt32();

            for (int i = 0; i < animCount; i++)
            {
                bundle.AddAnimation(LoadAnimationFromStream(stream, bundleVersion));
            }

            // The next block (Animation Sheets) are only available on version 2 and higher
            if (bundleVersion == 1)
                return bundle;

            // AnimationSheet block
            int sheetCount = reader.ReadInt32();

            for (int i = 0; i < sheetCount; i++)
            {
                bundle.AddAnimationSheet(LoadAnimationSheetFromStream(stream, bundle, bundleVersion));
            }

            stream.Close();

            return bundle;
        }