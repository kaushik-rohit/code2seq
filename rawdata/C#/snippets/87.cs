[Bam.Net.Exclude]
		public static NotificationSubscriptionCollection Where(WhereDelegate<NotificationSubscriptionColumns> where, OrderBy<NotificationSubscriptionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<NotificationSubscription>();
			var results = new NotificationSubscriptionCollection(database, database.GetQuery<NotificationSubscriptionColumns, NotificationSubscription>(where, orderBy), true);
			return results;
		}