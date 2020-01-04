public void SaveConfiguration()
        {
            configFile.Clear();
            configFile["Device"] = Device?.Name;
            configFile["VideoMode"] = VideoMode.Name;
            configFile["TimecodeMode"] = TimecodeMode.Name;
            configFile["Host"] = Host;
            configFile["Port"] = Port;
            configFile.Save();
        }