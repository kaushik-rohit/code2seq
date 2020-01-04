public boolean isValid(K key, UUID ticket) {
		if (timeouts.containsKey(key)) {
			Timeout<K> timeout = timeouts.get(key);

			return timeout.getTicket().equals(ticket);
		} else {
			return false;
		}
	}