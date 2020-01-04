public Graph LoadGraph(string path)
		{
			Graph g;
			if (path.Equals(BonConfig.DefaultGraphName)) g = CreateDefaultGraph();
			else g = Graph.Load(path);
			g.Name = path;
			Graphs.Add(g);
			CreateGraphController(g);
			g.UpdateNodes();
			return g;
		}