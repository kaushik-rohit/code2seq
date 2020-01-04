public void setZones(Map<String, List<URL>> zones) {
        if (zones != null) {
            this.otherZones = zones.entrySet()
                .stream()
                .flatMap((Function<Map.Entry<String, List<URL>>, Stream<ServiceInstance>>) entry ->
                    entry.getValue()
                        .stream()
                        .map(uriMapper())
                        .map(uri ->
                            ServiceInstance.builder(getServiceID(), uri)
                                .zone(entry.getKey())
                                .build()
                        ))
                .collect(Collectors.toList());
        }
    }