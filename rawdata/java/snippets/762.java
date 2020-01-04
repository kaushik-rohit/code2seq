@SuppressWarnings("unused")
	private String listAnnotationProcessorsBeforeOurs() {
		try {
			Object discoveredProcessors = javacProcessingEnvironment_discoveredProcs.get(this.javacProcessingEnv);
			ArrayList<?> states = (ArrayList<?>) discoveredProcessors_procStateList.get(discoveredProcessors);
			if (states == null || states.isEmpty()) return null;
			if (states.size() == 1) return processorState_processor.get(states.get(0)).getClass().getName();
			
			int idx = 0;
			StringBuilder out = new StringBuilder();
			for (Object processState : states) {
				idx++;
				String name = processorState_processor.get(processState).getClass().getName();
				if (out.length() > 0) out.append(", ");
				out.append("[").append(idx).append("] ").append(name);
			}
			return out.toString();
		} catch (Exception e) {
			return null;
		}
	}