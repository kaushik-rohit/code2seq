public override void CleanUp ()
        {
            var imagesToRelease = imageCache.Keys.Where (i => !imagesInUse.Contains (i)).ToList ();
            foreach (var i in imagesToRelease) {
                var image = GetImage (i);
                image.Dispose ();
                imageCache.Remove (i);
            }

            imagesInUse.Clear ();
        }