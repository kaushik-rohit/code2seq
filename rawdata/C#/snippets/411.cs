public override Texture Get(string name)
        {
            var baseTex = base.Get(name);

            if (baseTex?.TextureGL == null) return null;

            // encapsulate texture for ref counting
            return new TextureWithRefCount(baseTex.TextureGL) { ScaleAdjust = ScaleAdjust };
        }