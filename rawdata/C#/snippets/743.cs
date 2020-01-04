public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string setting;

            // Optional settings
            if (settings.TryGetValue("databaseName", out setting))
                m_databaseName = setting;

            if (settings.TryGetValue("collectionName", out setting))
                m_collectionName = setting;

            if (settings.TryGetValue("server", out setting))
                m_server = setting;

            if (settings.TryGetValue("port", out setting))
                m_port = int.Parse(setting);

            if (settings.TryGetValue("framesPerSecond", out setting))
                m_framesPerSecond = int.Parse(setting);

            if (settings.TryGetValue("simulateRealTime", out setting))
                m_simulateRealTime = Convert.ToBoolean(setting);

            // Override frames per second based on temporal processing interval if it's not set to default
            if (ProcessingInterval > -1)
            {
                if (ProcessingInterval == 0)
                {
                    m_framesPerSecond = 1000;
                }
                else
                {
                    // Minimum processing rate for this class is one frame per second
                    if (ProcessingInterval >= 1000)
                        m_framesPerSecond = 1;
                    else
                        m_framesPerSecond = 1000 / ProcessingInterval;
                }
            }
        }