[Bam.Net.Exclude]
		public static NotificationSubscription OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<NotificationSubscriptionColumns> whereDelegate = (c) => where;
			var result = Top(1, whereDelegate, database);
			return OneOrThrow(result);
		}