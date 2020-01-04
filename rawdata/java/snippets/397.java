public void sendMessageToAllNeighbors(Message m) {
		if (edgesUsed) {
			throw new IllegalStateException("Can use either 'getEdges()' or 'sendMessageToAllNeighbors()'"
					+ "exactly once.");
		}

		edgesUsed = true;
		outValue.f1 = m;

		while (edges.hasNext()) {
			Tuple next = (Tuple) edges.next();

			/*
			 * When EdgeDirection is OUT, the edges iterator only has the out-edges
			 * of the vertex, i.e. the ones where this vertex is src.
			 * next.getField(1) gives the neighbor of the vertex running this ScatterFunction.
			 */
			if (getDirection().equals(EdgeDirection.OUT)) {
				outValue.f0 = next.getField(1);
			}
			/*
			 * When EdgeDirection is IN, the edges iterator only has the in-edges
			 * of the vertex, i.e. the ones where this vertex is trg.
			 * next.getField(10) gives the neighbor of the vertex running this ScatterFunction.
			 */
			else if (getDirection().equals(EdgeDirection.IN)) {
				outValue.f0 = next.getField(0);
			}
			 // When EdgeDirection is ALL, the edges iterator contains both in- and out- edges
			if (getDirection().equals(EdgeDirection.ALL)) {
				if (next.getField(0).equals(vertexId)) {
					// send msg to the trg
					outValue.f0 = next.getField(1);
				}
				else {
					// send msg to the src
					outValue.f0 = next.getField(0);
				}
			}
			out.collect(outValue);
		}
	}