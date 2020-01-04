[Bam.Net.Exclude]
		public static NotificationSubscription GetOneWhere(WhereDelegate<NotificationSubscriptionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				NotificationSubscriptionColumns c = new NotificationSubscriptionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}