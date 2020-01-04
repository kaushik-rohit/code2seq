private void parameterize(Parameterized parameterized) {
		try {
			parameterized.configure(parameters);
		} catch (RuntimeException ex) {
			throw new ProgramParametrizationException(ex.getMessage());
		}
	}