private void InitVideoModes()
        {
            VideoModes = new ObservableCollection<VideoMode>
            {
                new VideoMode {Mode = _BMDDisplayMode.bmdModeHD1080p25, Name = "1080p25", Fps = 25000},
                new VideoMode {Mode = _BMDDisplayMode.bmdModeHD1080i50, Name = "1080i25", Fps = 25000},
                new VideoMode {Mode = _BMDDisplayMode.bmdModeHD1080p24, Name = "1080i24", Fps = 24000},
                new VideoMode {Mode = _BMDDisplayMode.bmdModeHD720p50,  Name = "720p25",  Fps = 25000},
                new VideoMode {Mode = _BMDDisplayMode.bmdModePAL,       Name = "PAL",     Fps = 25000},
                new VideoMode {Mode = _BMDDisplayMode.bmdModePALp,      Name = "PALp",    Fps = 25000}
            };
        }