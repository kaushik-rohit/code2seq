public static void SaveBundleToDisk(Bundle bundle, string path)
        {
            PixelariaFile file = new PixelariaFile(bundle, path);

            SaveFileToDisk(file);
        }