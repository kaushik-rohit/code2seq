public static NotificationSubscriptionCollection Where(QiQuery where, Database database = null)
		{
			var results = new NotificationSubscriptionCollection(database, Select<NotificationSubscriptionColumns>.From<NotificationSubscription>().Where(where, database));
			return results;
		}