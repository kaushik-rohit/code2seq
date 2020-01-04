public static NotificationSubscriptionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<NotificationSubscription>();
			QuerySet query = GetQuerySet(db);
			query.Top<NotificationSubscription>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<NotificationSubscriptionCollection>(0);
			results.Database = db;
			return results;
		}