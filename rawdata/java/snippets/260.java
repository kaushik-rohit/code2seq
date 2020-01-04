public static boolean degradeWeight(ProviderInfo providerInfo, int weight) {
        providerInfo.setStatus(ProviderStatus.DEGRADED);
        providerInfo.setWeight(weight);
        return true;
    }