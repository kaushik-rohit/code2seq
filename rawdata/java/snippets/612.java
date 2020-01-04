private static Plan createPlanFromProgram(Program program, String[] options) throws ProgramInvocationException {
		try {
			return program.getPlan(options);
		} catch (Throwable t) {
			throw new ProgramInvocationException("Error while calling the program: " + t.getMessage(), t);
		}
	}