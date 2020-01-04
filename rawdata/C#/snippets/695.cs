protected void OnTeleport(GamePlayer player, Teleport destination)
		{
			if (player.InCombat == false && GameRelic.IsPlayerCarryingRelic(player) == false)
			{
				player.LeaveHouse();
				GameLocation currentLocation = new GameLocation("TeleportStart", player.CurrentRegionID, player.X, player.Y, player.Z);
				player.MoveTo((ushort)destination.RegionID, destination.X, destination.Y, destination.Z, (ushort)destination.Heading);
				GameServer.ServerRules.OnPlayerTeleport(player, currentLocation, destination);
			}
		}