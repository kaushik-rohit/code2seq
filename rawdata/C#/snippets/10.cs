static public DroneViewEntry DroneEntryKonstrukt(
			UINodeInfoInTree entryAst,
			IColumnHeader[] listeScrollHeader,
			RectInt? regionConstraint)
		{
			if (!(entryAst?.VisibleIncludingInheritance ?? false))
				return null;

			var listEntryAuswert = new SictAuswertGbsListEntry(entryAst, listeScrollHeader, regionConstraint, ListEntryTrenungZeleTypEnum.Ast);

			listEntryAuswert.Berecne();

			var listEntry = listEntryAuswert.ErgeebnisListEntry;

			if (null == listEntry)
				return null;

			var LabelGröösteAst = entryAst?.LargestLabelInSubtree();

			var labelGrööste = LabelGröösteAst.AsUIElementTextIfTextNotEmpty();

			var isGroup = listEntry?.IsGroup ?? false;

			if (isGroup)
			{
				var Caption = labelGrööste;

				return new DroneViewEntryGroup(listEntry)
				{
					Caption = labelGrööste,
				};
			}
			else
			{
				var MengeContainerAst =
					entryAst.MatchingNodesFromSubtreeBreadthFirst(
					kandidaat => kandidaat.PyObjTypNameIsContainer(),
					null,
					3, 1);

				var GaugesAst =
					MengeContainerAst.SuuceFlacMengeAstFrüheste(
					kandidaat => string.Equals("gauges", kandidaat.Name, StringComparison.InvariantCultureIgnoreCase),
					1, 0);

				var MengeGaugeScpezContainerAst =
					GaugesAst.MatchingNodesFromSubtreeBreadthFirst(
					kandidaat => kandidaat.PyObjTypNameIsContainer(),
					null,
					1, 1,
					true);

				var DictZuTypSictStringTreferpunkte = new Dictionary<string, int?>();

				if (null != MengeGaugeScpezContainerAst)
				{
					foreach (var GaugeScpezContainerAst in MengeGaugeScpezContainerAst)
					{
						if (null == GaugeScpezContainerAst)
							continue;

						var GaugeScpezContainerAstName = GaugeScpezContainerAst.Name;

						if (null == GaugeScpezContainerAstName)
							continue;

						var nameMatch = GaugeScpezContainerAstName?.RegexMatchIfSuccess(DroneEntryGaugeScpezAstNameRegexPattern, RegexOptions.IgnoreCase);

						var typSictString = nameMatch?.Groups[1].Value;

						if (null == typSictString)
							continue;

						DictZuTypSictStringTreferpunkte[typSictString] = AusDroneEntryGaugeTreferpunkteRelMili(GaugeScpezContainerAst);
					}
				}

				var TreferpunkteStruct = DictZuTypSictStringTreferpunkte.FirstOrDefault(kandidaat => kandidaat.Key.ToLower().Contains("struct"));
				var TreferpunkteArmor = DictZuTypSictStringTreferpunkte.FirstOrDefault(kandidaat => kandidaat.Key.ToLower().Contains("armor"));
				var TreferpunkteShield = DictZuTypSictStringTreferpunkte.FirstOrDefault(kandidaat => kandidaat.Key.ToLower().Contains("shield"));

				var Treferpunkte = new ShipHitpointsAndEnergy
				{
					Struct = TreferpunkteStruct.Value,
					Armor = TreferpunkteArmor.Value,
					Shield = TreferpunkteShield.Value,
				};

				return new DroneViewEntryItem(listEntry)
				{
					Hitpoints = Treferpunkte,
				};
			}
		}