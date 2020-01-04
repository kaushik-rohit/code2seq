[Bam.Net.Exclude]
		public static NotificationSubscriptionCollection Where(Func<NotificationSubscriptionColumns, QueryFilter<NotificationSubscriptionColumns>> where, OrderBy<NotificationSubscriptionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<NotificationSubscription>();
			return new NotificationSubscriptionCollection(database.GetQuery<NotificationSubscriptionColumns, NotificationSubscription>(where, orderBy), true);
		}