[Bam.Net.Exclude]
		public static NotificationSubscription FirstOneWhere(WhereDelegate<NotificationSubscriptionColumns> where, Database database = null)
		{
			var results = Top(1, where, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}