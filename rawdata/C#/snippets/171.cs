public static AnimationExportSettings LoadExportSettingsFromStream(Stream stream, int version)
        {
            BinaryReader reader = new BinaryReader(stream);

            AnimationExportSettings settings = new AnimationExportSettings
            {
                FavorRatioOverArea = reader.ReadBoolean(),
                ForcePowerOfTwoDimensions = reader.ReadBoolean(),
                ForceMinimumDimensions = reader.ReadBoolean(),
                ReuseIdenticalFramesArea = reader.ReadBoolean(),
                // >= Version 4
                HighPrecisionAreaMatching = version >= 4 && reader.ReadBoolean(),
                AllowUnorderedFrames = reader.ReadBoolean(),
                // >= Version 7
                UseUniformGrid = version >= 7 && reader.ReadBoolean(),
                UsePaddingOnJson = reader.ReadBoolean(),
                // >= Version 5
                ExportJson = version < 5 || reader.ReadBoolean(),
                XPadding = reader.ReadInt32(),
                YPadding = reader.ReadInt32()
            };

            return settings;
        }