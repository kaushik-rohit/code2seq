public static QueryableStateConfiguration disabled() {
		final Iterator<Integer> proxyPorts = NetUtils.getPortRangeFromString(QueryableStateOptions.PROXY_PORT_RANGE.defaultValue());
		final Iterator<Integer> serverPorts = NetUtils.getPortRangeFromString(QueryableStateOptions.SERVER_PORT_RANGE.defaultValue());
		return new QueryableStateConfiguration(proxyPorts, serverPorts, 0, 0, 0, 0);
	}