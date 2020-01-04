public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player))
				return false;

			String intro = String.Format("Greetings. I can channel the energies of this place to send you {0} {1} {2} {3} {4} {5} {6}",
			                             "to far away lands. If you wish to fight in the Frontiers I can send you to [Forest Sauvage] or to the",
			                             "border keeps [Castle Sauvage] and [Snowdonia Fortress]. Maybe you wish to undertake the Trials of",
			                             "Atlantis in [Oceanus] haven or wish to visit the harbor of [Gothwaite] and the [Shrouded Isles]?",
			                             "You could explore the [Avalon Marsh] or perhaps you would prefer the comforts of the [housing] regions.",
			                             "Perhaps the fierce [Battlegrounds] are more to your liking or do you wish to meet the citizens inside",
			                             "the great city of [Camelot] or the [Inconnu Crypt]?",
			                             "Or perhaps you are interested in porting to our training camp [Holtham]?");
			SayTo(player, intro);
			return true;
		}