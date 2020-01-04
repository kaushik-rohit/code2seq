@Deprecated
	@SuppressWarnings("unchecked")
	public void addInput(List<Operator<IN>> inputs) {
		this.input = Operator.createUnionCascade(this.input, inputs.toArray(new Operator[inputs.size()]));
	}