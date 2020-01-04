public static synchronized IClient<?, ?> registerClientFromProperties(String restClientName, IClientConfig clientConfig) throws ClientException { 
    	IClient<?, ?> client = null;
    	ILoadBalancer loadBalancer = null;
    	if (simpleClientMap.get(restClientName) != null) {
    		throw new ClientException(
    				ClientException.ErrorType.GENERAL,
    				"A Rest Client with this name is already registered. Please use a different name");
    	}
    	try {
    		String clientClassName = clientConfig.getOrDefault(CommonClientConfigKey.ClientClassName);
    		client = (IClient<?, ?>) instantiateInstanceWithClientConfig(clientClassName, clientConfig);
    		boolean initializeNFLoadBalancer = clientConfig.getOrDefault(CommonClientConfigKey.InitializeNFLoadBalancer);
    		if (initializeNFLoadBalancer) {
    			loadBalancer = registerNamedLoadBalancerFromclientConfig(restClientName, clientConfig);
    		}
    		if (client instanceof AbstractLoadBalancerAwareClient) {
    			((AbstractLoadBalancerAwareClient) client).setLoadBalancer(loadBalancer);
    		}
    	} catch (Throwable e) {
    		String message = "Unable to InitializeAndAssociateNFLoadBalancer set for RestClient:"
    				+ restClientName;
    		logger.warn(message, e);
    		throw new ClientException(ClientException.ErrorType.CONFIGURATION, 
    				message, e);
    	}
    	simpleClientMap.put(restClientName, client);

    	Monitors.registerObject("Client_" + restClientName, client);

    	logger.info("Client Registered:" + client.toString());
    	return client;
    }