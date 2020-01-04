public static boolean isDetachedPlugin(@Nonnull String pluginId) {
        for (DetachedPlugin detachedPlugin : getDetachedPlugins()) {
            if (detachedPlugin.getShortName().equals(pluginId)) {
                return true;
            }
        }

        return false;
    }