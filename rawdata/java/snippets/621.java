@Override
	public void open(InputSplit ignored) throws IOException {
		this.session = cluster.connect();
		this.resultSet = session.execute(query);
	}