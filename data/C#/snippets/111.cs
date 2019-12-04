[Bam.Net.Exclude]
		public static NotificationSubscriptionCollection Top(int count, WhereDelegate<NotificationSubscriptionColumns> where, OrderBy<NotificationSubscriptionColumns> orderBy, Database database = null)
		{
			NotificationSubscriptionColumns c = new NotificationSubscriptionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<NotificationSubscription>();
			QuerySet query = GetQuerySet(db); 
			query.Top<NotificationSubscription>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<NotificationSubscriptionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<NotificationSubscriptionCollection>(0);
			results.Database = db;
			return results;
		}