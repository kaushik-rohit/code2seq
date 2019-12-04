public static void Apply(PacketEntities packetEntities, IBitStream reader, DemoParser parser)
        {
			int currentEntity = -1;

			for (int i = 0; i < packetEntities.UpdatedEntries; i++) {

				//First read which entity is updated
				currentEntity += 1 + (int)reader.ReadUBitInt();

				//Find out whether we should create, destroy or update it. 
				// Leave flag
				if (!reader.ReadBit()) {
					// enter flag
					if (reader.ReadBit()) {
						//create it
						var e = ReadEnterPVS(reader, currentEntity, parser);

						parser.Entities[currentEntity] = e;

						e.ApplyUpdate(reader);
					} else {
						// preserve / update
						Entity e = parser.Entities[currentEntity];
						e.ApplyUpdate(reader);
					}
				} else {
					Entity e = parser.Entities[currentEntity];
					e.ServerClass.AnnounceDestroyedEntity(e);

					// leave / destroy
					e.Leave ();
					parser.Entities[currentEntity] = null;

					//dunno, but you gotta read this.
					if (reader.ReadBit()) {
					}
				}
			}
        }