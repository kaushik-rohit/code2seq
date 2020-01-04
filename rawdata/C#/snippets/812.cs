public static void SoundGetWaveVolume(out int output, int device)
        {
            output = 0;

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                return;

            uint vol = 0;
            WindowsAPI.waveOutGetVolume(new IntPtr(device), out vol);
            output = (int)vol;

            // UNDONE: cross platform SoundGetWaveVolume
        }