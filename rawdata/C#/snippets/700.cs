public override  bool CanComplete(SimulationContext context, out long? skipFurtherChecksUntilTimePeriod){
			skipFurtherChecksUntilTimePeriod = null;

			bool canComplete = false;

			if (Events != null && Events.Count > 0){
				canComplete = true;
			}

			return canComplete;
		}