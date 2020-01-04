[Bam.Net.Exclude]
		public static long Count(WhereDelegate<NotificationSubscriptionColumns> where, Database database = null)
		{
			NotificationSubscriptionColumns c = new NotificationSubscriptionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<NotificationSubscription>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<NotificationSubscription>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}