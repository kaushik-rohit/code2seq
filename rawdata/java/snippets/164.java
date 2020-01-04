public static IClientConfig getNamedConfig(String name, Class<? extends IClientConfig> clientConfigClass) {
        return getNamedConfig(name, factoryFromConfigType(clientConfigClass));
    }