public void recordEvaluationCandidates(List<String> evaluationCandidates) {
		Assert.notNull(evaluationCandidates, "evaluationCandidates must not be null");
		this.unconditionalClasses.addAll(evaluationCandidates);
	}