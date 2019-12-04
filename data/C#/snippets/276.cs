protected override void OnDestinationPicked(GamePlayer player, Teleport destination)
		{
			switch (destination.TeleportID.ToLower())
			{
				case "avalon marsh":
					SayTo(player, "You shall soon arrive in the Avalon Marsh.");
					break;
				case "battlegrounds":
					if (!ServerProperties.Properties.BG_ZONES_OPENED && player.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
					{
						SayTo(player, ServerProperties.Properties.BG_ZONES_CLOSED_MESSAGE);
						return;
					}

					SayTo(player, "I will teleport you to the appropriate battleground for your level and Realm Rank. If you exceed the Realm Rank for a battleground, you will not teleport. Please gain more experience to go to the next battleground.");
					break;
				case "camelot":
					SayTo(player, "The great city awaits!");
					break;
				case "castle sauvage":
					SayTo(player, "Castle Sauvage is what you seek, and Castle Sauvage is what you shall find.");
					break;
				case "diogel":
					break;	// No text?
				case "entrance":
					break;	// No text?
				case "forest sauvage":
					SayTo(player, "Now to the Frontiers for the glory of the realm!");
					break;
				case "gothwaite":
					SayTo(player, "The Shrouded Isles await you.");
					break;
				case "gwyntell":
					break;	// No text?
				case "inconnu crypt":
					//if (player.HasFinishedQuest(typeof(InconnuCrypt)) <= 0)
					//{
					//	SayTo(player, String.Format("I may only send those who know the way to this {0} {1}",
					//	                            "city. Seek out the path to the city and in future times I will aid you in",
					//	                            "this journey."));
					//	return;
					//}
					break;
				case "oceanus":
					if (player.Client.Account.PrivLevel < ServerProperties.Properties.ATLANTIS_TELEPORT_PLVL)
					{
						SayTo(player, "I'm sorry, but you are not authorized to enter Atlantis at this time.");
						return;
					}
					SayTo(player, "You will soon arrive in the Haven of Oceanus.");
					break;
				case "personal":
					break;
				case "hearth":
					break;
				case "snowdonia fortress":
					SayTo(player, "Snowdonia Fortress is what you seek, and Snowdonia Fortress is what you shall find.");
					break;
					// text for the following ?
				case "wearyall":
					break;
				case "holtham":
					if (ServerProperties.Properties.DISABLE_TUTORIAL)
					{
						SayTo(player,"Sorry, this place is not available for now !");
						return;
					}
					if (player.Level > 15)
					{
						SayTo(player,"Sorry, you are far too experienced to enjoy this place !");
						return;
					}
					break;
				default:
					SayTo(player, "This destination is not yet supported.");
					return;
			}
			base.OnDestinationPicked(player, destination);
		}