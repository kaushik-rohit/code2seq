[Bam.Net.Exclude]
		public static NotificationSubscription FirstOneWhere(QueryFilter where, OrderBy<NotificationSubscriptionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<NotificationSubscriptionColumns> whereDelegate = (c) => where;
			var results = Top(1, whereDelegate, orderBy, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}