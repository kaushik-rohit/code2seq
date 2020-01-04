public static void RemovePath(ref string fileName)
        {
            int indexOf1 = fileName.LastIndexOf('/', fileName.Length - 1, fileName.Length);
            if (indexOf1 == fileName.Length - 1 && fileName.Length > 1)
            {
                indexOf1 = fileName.LastIndexOf('/', fileName.Length - 2, fileName.Length - 1);
            }

            int indexOf2 = fileName.LastIndexOf('\\', fileName.Length - 1, fileName.Length);
            if (indexOf2 == fileName.Length - 1 && fileName.Length > 1)
            {
                indexOf2 = fileName.LastIndexOf('\\', fileName.Length - 2, fileName.Length - 1);
            }


            if (indexOf1 > indexOf2)
                fileName = fileName.Remove(0, indexOf1 + 1);
            else if (indexOf2 != -1)
                fileName = fileName.Remove(0, indexOf2 + 1);
        }