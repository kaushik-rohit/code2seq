private DataSet<Edge<K, EV>> getPairwiseEdgeIntersection(DataSet<Edge<K, EV>> edges) {
		return this.getEdges()
				.coGroup(edges)
				.where(0, 1, 2)
				.equalTo(0, 1, 2)
				.with(new MatchingEdgeReducer<>())
					.name("Intersect edges");
	}