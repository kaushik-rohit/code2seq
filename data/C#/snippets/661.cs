public void RestoreConfiguration()
        {
            Device = Devices.SingleOrDefault(d => d.Name == configFile["Device"]);
            VideoMode = VideoModes.SingleOrDefault(v => v.Name == configFile["VideoMode"]) ?? VideoModes.First();
            TimecodeMode = TimecodeModes.SingleOrDefault(t => t.Name == configFile["TimecodeMode"]) ?? TimecodeModes.First();
            Host = configFile["Host"];
            Port = configFile["Port"];
            FirLength = configFile["FirLength"];
            Validate();
        }