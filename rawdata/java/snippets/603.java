public static InetSocketAddress buildInetSocketAddress(String host, int defaultPort) {
		if (StrUtil.isBlank(host)) {
			host = LOCAL_IP;
		}

		String destHost = null;
		int port = 0;
		int index = host.indexOf(":");
		if (index != -1) {
			// host:port形式
			destHost = host.substring(0, index);
			port = Integer.parseInt(host.substring(index + 1));
		} else {
			destHost = host;
			port = defaultPort;
		}

		return new InetSocketAddress(destHost, port);
	}