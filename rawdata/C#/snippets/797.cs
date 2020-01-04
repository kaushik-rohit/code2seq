protected override void ReadHeadersFromConfig(AppConfig config)
        {
            AdManagerAppConfig adManagerConfig = (AdManagerAppConfig) config;

            this.requestHeader = new RequestHeader();
            this.requestHeader.networkCode = adManagerConfig.NetworkCode;
            this.requestHeader.applicationName = adManagerConfig.GetUserAgent();
        }