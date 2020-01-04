public static String ipAddressToUrlString(InetAddress address) {
		if (address == null) {
			throw new NullPointerException("address is null");
		}
		else if (address instanceof Inet4Address) {
			return address.getHostAddress();
		}
		else if (address instanceof Inet6Address) {
			return getIPv6UrlRepresentation((Inet6Address) address);
		}
		else {
			throw new IllegalArgumentException("Unrecognized type of InetAddress: " + address);
		}
	}