[Bam.Net.Exclude]
		public static NotificationSubscription OneWhere(WhereDelegate<NotificationSubscriptionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}