[Bam.Net.Exclude]
		public static NotificationSubscriptionCollection Where(WhereDelegate<NotificationSubscriptionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<NotificationSubscription>();
			var results = new NotificationSubscriptionCollection(database, database.GetQuery<NotificationSubscriptionColumns, NotificationSubscription>(where), true);
			return results;
		}