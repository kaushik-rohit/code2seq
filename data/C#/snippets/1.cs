private CommandProfile GetProfile(Settings settings)
        {
            return new CommandProfile()
            {
                UpLoadPath = settings.SYS_UpLoadPath,
                DownLoadPath = settings.SYS_DownLoadPath,
                UpLoadFName = settings.SYS_UpLoadFName,
                DownLoadFName = settings.SYS_DownLoadFName,
            };
        }