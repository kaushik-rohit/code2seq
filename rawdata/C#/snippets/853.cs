public BasicAppHost Init()
        {
            EndpointHost.ConfigureHost(this, GetType().Name, Config.ServiceManager);
            return this;
        }