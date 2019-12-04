private static Entity ReadEnterPVS(IBitStream reader, int id, DemoParser parser)
        {
			//What kind of entity?
            int serverClassID = (int)reader.ReadInt(parser.SendTableParser.ClassBits);

			//So find the correct server class
            ServerClass entityClass = parser.SendTableParser.ServerClasses[serverClassID];

            reader.ReadInt(10); //Entity serial. 
			//Never used anywhere I guess. Every parser just skips this


			Entity newEntity = new Entity(id, entityClass);

			//give people the chance to subscribe to events for this
			newEntity.ServerClass.AnnounceNewEntity(newEntity);

			//And then parse the instancebaseline. 
			//basically you could call
			//newEntity.ApplyUpdate(parser.instanceBaseline[entityClass]; 
			//This code below is just faster, since it only parses stuff once
			//which is faster. 

			object[] fastBaseline;
			if (parser.PreprocessedBaselines.TryGetValue(serverClassID, out fastBaseline))
				PropertyEntry.Emit(newEntity, fastBaseline);
			else {
				var preprocessedBaseline = new List<object>();
				if (parser.instanceBaseline.ContainsKey(serverClassID))
					using (var collector = new PropertyCollector(newEntity, preprocessedBaseline))
					using (var bitStream = BitStreamUtil.Create(parser.instanceBaseline[serverClassID]))
						newEntity.ApplyUpdate(bitStream);

				parser.PreprocessedBaselines.Add(serverClassID, preprocessedBaseline.ToArray());
			}

            return newEntity;
        }