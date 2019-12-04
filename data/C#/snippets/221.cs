public static void FocusDownloader()
        {
            var hwnd = FindWindow(null, "Anime Downloader");
            ShowWindow(hwnd, Restore);
            SetForegroundWindow(hwnd);
        }