public static void SoundSetWaveVolume(string percent, int device)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                return;

            if (string.IsNullOrEmpty(percent))
                percent = "0";

            var dev = new IntPtr(device);
            uint vol;

            char p = percent[0];
            if (p == '+' || p == '-')
            {
                WindowsAPI.waveOutGetVolume(dev, out vol);
                vol = (uint)(vol * double.Parse(percent.Substring(1)) / 100);
            }
            else
                vol = (uint)(0xfffff * (double.Parse(percent) / 100));

            WindowsAPI.waveOutSetVolume(dev, vol);

            // TODO: cross platform SoundSetWaveVolume
        }