public static UUID fastUUID() {
		ThreadLocalRandom random = ThreadLocalRandom.current();
		return new UUID(random.nextLong(), random.nextLong());
	}