public int getExitCode() {
		int exitCode = 0;
		for (ExitCodeGenerator generator : this.generators) {
			try {
				int value = generator.getExitCode();
				if (value > 0 && value > exitCode || value < 0 && value < exitCode) {
					exitCode = value;
				}
			}
			catch (Exception ex) {
				exitCode = (exitCode != 0) ? exitCode : 1;
				ex.printStackTrace();
			}
		}
		return exitCode;
	}