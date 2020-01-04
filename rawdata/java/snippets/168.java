public void addBroadcastSetForScatterFunction(String name, DataSet<?> data) {
		this.bcVarsScatter.add(new Tuple2<>(name, data));
	}