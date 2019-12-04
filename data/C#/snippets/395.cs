public Graph CreateDefaultGraph()
		{
			Graph graph = new Graph();

			// Number Nodes
			var operator01 = (NumberOperatorNode) graph.CreateNode<NumberOperatorNode>();
			operator01.X = 200;
			operator01.Y = 40;
			operator01.SetMode(Operator.Add);
			graph.AddNode(operator01);

			var diplay01 = (NumberDisplayNode) graph.CreateNode<NumberDisplayNode>();
			diplay01.X = 330;
			diplay01.Y = 80;
			graph.AddNode(diplay01);

			graph.Link(
				(InputSocket) diplay01.GetSocket(typeof(AbstractNumberNode), typeof(InputSocket), 0),
				(OutputSocket) operator01.GetSocket(typeof(AbstractNumberNode), typeof(OutputSocket), 0));

			// Map2D Nodes
			var perlinNoise = graph.CreateNode<UnityPerlinNoiseNode>();
			perlinNoise.X = 80;
			perlinNoise.Y = 250;
			graph.AddNode(perlinNoise);

			var displayMap = graph.CreateNode<NoiseDisplayNode>();
			displayMap.X = 300;
			displayMap.Y = 280;
			graph.AddNode(displayMap);

			graph.Link(
				(InputSocket) displayMap.GetSocket(typeof(AbstractNumberNode), typeof(InputSocket), 0),
				(OutputSocket) perlinNoise.GetSocket(typeof(AbstractNumberNode), typeof(OutputSocket), 0));


			// == test serialization an deserialization ==
			var serializedJSON = graph.ToJson();
			var deserializedGraph = Graph.FromJson(serializedJSON);
			// =====

			return deserializedGraph;
		}