public void Open(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            if (extension != null)
            {
                if (extension.ToLower() == ".ico")
                {
                    Icon ico = new Icon(fileName);
                    Picture = ico.ToBitmap();
                }
                else
                {
                    Picture = Image.FromFile(fileName);
                }
            }

            _pictureFilename = fileName;
        }