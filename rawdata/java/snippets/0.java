public static String getExtractorRuleDefinitionFileName(final String rootDir, final DatabaseType databaseType) {
        return Joiner.on('/').join(rootDir, databaseType.name().toLowerCase(), EXTRACTOR_RULE_DEFINITION_FILE_NAME);
    }