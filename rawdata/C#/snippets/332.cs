public static SelfHostResult EnableName(Action<NAMEKestrelConfiguration> nameConfigBuilder)
        {
            var config = new NAMEKestrelConfiguration();
            nameConfigBuilder?.Invoke(config);

            var pathMapper = new StaticFilePathMapper();

            var server = new KestrelServer(config, pathMapper);
            var parsedDependencies = SelfHostInitializer.Initialize(server, pathMapper, config);

            return new SelfHostResult(parsedDependencies, server);
        }