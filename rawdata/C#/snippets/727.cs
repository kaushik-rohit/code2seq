public static WeightedALGraph<TVertex, TWeight> KruskalMST<TVertex, TWeight>(this IWeightedGraph<TVertex, TWeight> graph)
            where TVertex : IComparable<TVertex>
            where TWeight : IComparable<TWeight>
        {
            if (graph.IsDirected)
                throw new ArgumentException("Graph is directed!");

            var mst = new WeightedALGraph<TVertex, TWeight>();

            // A dictionary of the added vertices to the MST and their tree identifiers (first vertex from the tree)
            var addedVertices = new Dictionary<TVertex, TVertex>();
            // Edge comparer for the edge sorting
            var edgeComparer = Comparer<IWeightedEdge<TVertex, TWeight>>.Create((x, y) =>
            {
                int cmp = 0;
                // null checking because TWeight can be null
                if (x.Weight == null)
                {
                    if (y.Weight == null) cmp = -1; // change cmp to skip next comparisons
                    else return int.MinValue;
                }

                if (cmp == 0)// if Weights are not both null
                {
                    if (y.Weight == null) return int.MaxValue;
                    // normal check if both weights are not null
                    cmp = x.Weight.CompareTo(y.Weight);
                }
                else cmp = 0;// if both Weights were null, compare the kvp value

                if (cmp == 0) cmp = x.Source.CompareTo(y.Source);
                if (cmp == 0) cmp = x.Destination.CompareTo(y.Destination);
                return cmp;
            });

            var vertices = graph.Vertices.ToList();
            if (vertices.Count == 0) return mst;
            
            mst.AddVertices(vertices);

            // Get edges
            var edges = graph.Edges.ToList();
            if (edges.Count == 0) return mst;
            // Sort them
            edges.QuickSort(edgeComparer);

            for (int i = 0; i < edges.Count; i++)
            {
                var curEdge = edges[i];

                if (addedVertices.ContainsKey(curEdge.Source))
                {
                    if (addedVertices.ContainsKey(curEdge.Destination))// if both vertices are added to the MST
                    {
                        // Find tree roots
                        var srcRoot = FindTreeRoot(addedVertices, curEdge.Source);
                        var dstRoot = FindTreeRoot(addedVertices, curEdge.Destination);

                        // If vertices belong to the same tree we continue. Edge will create a cycle.
                        if (object.Equals(srcRoot, dstRoot))
                            continue;
                        else // if not add edge and connect the trees
                        {
                            // Add edge to MST
                            mst.AddEdge(curEdge.Source, curEdge.Destination, curEdge.Weight);
                            // Connect destination vertex tree with the source
                            addedVertices[curEdge.Destination] = srcRoot;
                            addedVertices[dstRoot] = srcRoot;
                        }
                    }
                    else // if the source is added to the MST but not the destination
                    {
                        // Add edge to MST
                        mst.AddEdge(curEdge.Source, curEdge.Destination, curEdge.Weight);
                        // Find tree root
                        var srcRoot = FindTreeRoot(addedVertices, curEdge.Source);
                        // Add to the tree
                        addedVertices.Add(curEdge.Destination, srcRoot);
                    }
                }
                else // if the source is not added to the MST
                {
                    if (addedVertices.ContainsKey(curEdge.Destination))// if the destination is added
                    {
                        // Add edge to MST
                        mst.AddEdge(curEdge.Source, curEdge.Destination, curEdge.Weight);
                        // Find tree root
                        var dstRoot = FindTreeRoot(addedVertices, curEdge.Destination);
                        // Add to the tree
                        addedVertices.Add(curEdge.Source, dstRoot);
                    }
                    else// if both vertices are not added to the MST
                    {
                        // Add edge to MST
                        mst.AddEdge(curEdge.Source, curEdge.Destination, curEdge.Weight);
                        // Connect the vertices in a tree
                        addedVertices.Add(curEdge.Source, curEdge.Source);
                        addedVertices.Add(curEdge.Destination, curEdge.Source);
                    }
                }
            }

            // Return MST
            return mst;
        }