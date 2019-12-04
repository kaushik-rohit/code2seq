public static void DisplayInStatusBar(IServiceProvider serviceProvider, string msg)
        {
            var statusBar = GetStatusBar(serviceProvider);
            int frozen;
            statusBar.IsFrozen(out frozen);
            if (frozen == 0)
            {
                statusBar.SetText(msg);
            }
        }