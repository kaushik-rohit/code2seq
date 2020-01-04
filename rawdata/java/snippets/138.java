private void saveFeatures(List<Feature> features, FeatureCollector collector) {
        features.forEach(f -> {
            f.setCollectorId(collector.getId());
            Feature existing = featureRepository.findByCollectorIdAndSIdAndSTeamID(collector.getId(), f.getsId(), f.getsTeamID());
            if (existing != null) {
                f.setId(existing.getId());
            }
            featureRepository.save(f);
        });
    }