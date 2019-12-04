[Bam.Net.Exclude]
		public static NotificationSubscriptionCollection Top(int count, QueryFilter where, OrderBy<NotificationSubscriptionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<NotificationSubscription>();
			QuerySet query = GetQuerySet(db);
			query.Top<NotificationSubscription>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<NotificationSubscriptionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<NotificationSubscriptionCollection>(0);
			results.Database = db;
			return results;
		}