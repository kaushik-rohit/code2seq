protected override void OnSubSelectionPicked(GamePlayer player, Teleport subSelection)
		{
			switch (subSelection.TeleportID.ToLower())
			{
				case "shrouded isles":
					{
						String reply = String.Format("The isles of Avalon are an excellent choice. {0} {1}",
						                             "Would you prefer the harbor of [Gothwaite] or perhaps one of the outlying towns",
						                             "like [Wearyall] Village, Fort [Gwyntell], or Caer [Diogel]?");
						SayTo(player, reply);
						return;
					}
				case "housing":
					{
						String reply = String.Format("I can send you to your [personal] house. If you do {0} {1} {2} {3}",
						                             "not have a personal house or wish to be sent to the housing [entrance] then you will",
						                             "arrive just inside the housing area. I can also send you to your [guild] house. If your",
						                             "guild does not own a house then you will not be transported. You may go to your [Hearth] bind",
						                             "as well if you are bound inside a house.");
						SayTo(player, reply);
						return;
					}
			}
			base.OnSubSelectionPicked(player, subSelection);
		}