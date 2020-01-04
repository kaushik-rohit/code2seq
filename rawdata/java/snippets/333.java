public void initialize(IGraph<V, E> graph) {
        int nVertices = graph.numVertices();
        int[] degrees = new int[nVertices];
        for (int i = 0; i < nVertices; i++)
            degrees[i] = graph.getVertexDegree(i);
        initialize(degrees);
    }