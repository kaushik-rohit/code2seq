public static void Load(PixelariaFile file, bool resetBundle = true)
        {
            // TODO: Verify correctess of clearing the pixelaria file's internal blocks list before loading the file from the stream again
            PixelariaFileLoader loader = new PixelariaFileLoader(file, resetBundle);
            loader.Load();
        }