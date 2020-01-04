public static Animation LoadAnimationFromStream(Stream stream, int version)
        {
            BinaryReader reader = new BinaryReader(stream);

            int id = -1;
            if (version >= 2)
            {
                id = reader.ReadInt32();
            }
            string name = reader.ReadString();
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();
            int fps = reader.ReadInt32();
            bool frameskip = reader.ReadBoolean();

            Animation anim = new Animation(name, width, height)
            {
                ID = id,
                PlaybackSettings = new AnimationPlaybackSettings { FPS = fps, FrameSkip = frameskip }
            };

            int frameCount = reader.ReadInt32();

            for (int i = 0; i < frameCount; i++)
            {
                anim.AddFrame(LoadFrameFromStream(stream, anim, version));
            }

            return anim;
        }