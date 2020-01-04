public static Optional<Throwable> findThrowableWithMessage(Throwable throwable, String searchMessage) {
		if (throwable == null || searchMessage == null) {
			return Optional.empty();
		}

		Throwable t = throwable;
		while (t != null) {
			if (t.getMessage() != null && t.getMessage().contains(searchMessage)) {
				return Optional.of(t);
			} else {
				t = t.getCause();
			}
		}

		return Optional.empty();
	}