public void collect(AWSCloudCollector collector) {
        log("Starting AWS collection...");
        log("Collecting AWS Cloud Data...");

        Map<String, List<CloudInstance>> accountToInstanceMap = collectInstances();

        Map<String, String> instanceToAccountMap = new HashMap<>();
        for (String account : accountToInstanceMap.keySet()) {
            Collection<CloudInstance> instanceList = accountToInstanceMap.get(account);
            for (CloudInstance ci : instanceList) {
                instanceToAccountMap.put(ci.getInstanceId(), account);
            }
        }
        collectVolume(instanceToAccountMap);

        log("Finished Cloud collection.");
    }