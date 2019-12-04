private Image GetImage (OxyImage source)
        {
            if (source == null)
                return null;

            if (!this.imagesInUse.Contains (source))
                this.imagesInUse.Add (source);

            Image src;
            if (this.imageCache.TryGetValue (source, out src))
                return src;


            Image btm;
            using (var ms = new System.IO.MemoryStream (source.GetData ())) {
                btm = Image.FromStream (ms);
            }

            imageCache.Add (source, btm);
            return btm;
        }