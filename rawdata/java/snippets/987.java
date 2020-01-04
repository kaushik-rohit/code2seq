public static void parseTraceKey(Map<String, String> tracerMap, String key, String value) {
        String lowKey = key.substring(PREFIX.length());
        String realKey = TRACER_KEY_MAP.get(lowKey);
        tracerMap.put(realKey == null ? lowKey : realKey, value);
    }