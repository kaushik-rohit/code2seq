public static void Save(PixelariaFile file)
        {
            PixelariaFileSaver saver = new PixelariaFileSaver(file);
            saver.Save();
        }