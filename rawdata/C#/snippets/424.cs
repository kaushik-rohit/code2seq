public void StartBrowser(Dictionary<string, string> additionalCapabilities = null)
        {
            if (Browser == null)
            {
                _settings.ExtendAdditionalRemoteDriverCapabilities(additionalCapabilities);
                var driverFactory = new RemoteDriverFactory(_settings);
                Browser = new Browser(driverFactory.GetDriver(), _settings);
            }
            else
            {
                throw new WebDriverException("Multiple browser instances for this test has been detected, test will be terminated.");
            }
        }