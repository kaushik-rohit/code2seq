@SuppressWarnings("unchecked")
  @VisibleForTesting
  public static List<Map<String, ?>> getLoadBalancingConfigsFromServiceConfig(
      Map<String, ?> serviceConfig) {
    /* schema as follows
    {
      "loadBalancingConfig": [
        {"xds" :
          {
            "balancerName": "balancer1",
            "childPolicy": [...],
            "fallbackPolicy": [...],
          }
        },
        {"round_robin": {}}
      ],
      "loadBalancingPolicy": "ROUND_ROBIN"  // The deprecated policy key
    }
    */
    List<Map<String, ?>> lbConfigs = new ArrayList<>();
    if (serviceConfig.containsKey(SERVICE_CONFIG_LOAD_BALANCING_CONFIG_KEY)) {
      List<?> configs = getList(serviceConfig, SERVICE_CONFIG_LOAD_BALANCING_CONFIG_KEY);
      for (Map<String, ?> config : checkObjectList(configs)) {
        lbConfigs.add(config);
      }
    }
    if (lbConfigs.isEmpty()) {
      // No LoadBalancingConfig found.  Fall back to the deprecated LoadBalancingPolicy
      if (serviceConfig.containsKey(SERVICE_CONFIG_LOAD_BALANCING_POLICY_KEY)) {
        // TODO(zhangkun83): check if this is null.
        String policy = getString(serviceConfig, SERVICE_CONFIG_LOAD_BALANCING_POLICY_KEY);
        // Convert the policy to a config, so that the caller can handle them in the same way.
        policy = policy.toLowerCase(Locale.ROOT);
        Map<String, ?> fakeConfig = Collections.singletonMap(policy, Collections.emptyMap());
        lbConfigs.add(fakeConfig);
      }
    }
    return Collections.unmodifiableList(lbConfigs);
  }