@Override
    public void loadRemoteConfig() {
        try {
            // 加载远程adapter配置
            ConfigItem configItem = getRemoteAdapterConfig();
            if (configItem != null) {
                if (configItem.getModifiedTime() != currentConfigTimestamp) {
                    currentConfigTimestamp = configItem.getModifiedTime();
                    overrideLocalCanalConfig(configItem.getContent());
                    logger.info("## Loaded remote adapter config: application.yml");
                }
            }
        } catch (Exception e) {
            logger.error(e.getMessage(), e);
        }
    }