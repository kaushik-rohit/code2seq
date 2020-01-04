public static void populateMetadata(AbstractComputeInstanceMetadata instanceMetadata, Map<?, ?> metadata) {
        if (metadata != null) {
            Map<String, String> finalMetadata = new HashMap<>(metadata.size());
            for (Map.Entry<?, ?> entry : metadata.entrySet()) {
                Object key = entry.getKey();
                Object value = entry.getValue();
                if (value instanceof String) {
                    finalMetadata.put(key.toString(), value.toString());
                }
            }
            instanceMetadata.setMetadata(finalMetadata);
        }
    }