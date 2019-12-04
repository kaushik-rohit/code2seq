public void Dispose ()
        {
            foreach (var image in this.imageCache.Values) {
                image.Dispose ();
            }
        }