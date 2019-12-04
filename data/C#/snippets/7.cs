public static NotificationSubscriptionCollection LoadAll(Database database = null)
		{
			Database db = database ?? Db.For<NotificationSubscription>();
			SqlStringBuilder sql = db.GetSqlStringBuilder();
			sql.Select<NotificationSubscription>();
			var results = new NotificationSubscriptionCollection(db, sql.GetDataTable(db))
			{
				Database = db
			};
			return results;
		}