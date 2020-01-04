public static Map<String, Object> parseModelConfig(String modelJson, String modelYaml)
            throws IOException, InvalidKerasConfigurationException {
        Map<String, Object> modelConfig;
        if (modelJson != null)
            modelConfig = parseJsonString(modelJson);
        else if (modelYaml != null)
            modelConfig = parseYamlString(modelYaml);
        else
            throw new InvalidKerasConfigurationException("Requires model configuration as either JSON or YAML string.");
        return modelConfig;
    }