public static void registerCustomLayer(String layerName, Class<? extends KerasLayer> configClass) {
        customLayers.put(layerName, configClass);
    }