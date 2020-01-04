public static long Count(Database database = null)
        {
			Database db = database ?? Db.For<NotificationSubscription>();
            QuerySet query = GetQuerySet(db);
            query.Count<NotificationSubscription>();
            query.Execute(db);
            return (long)query.Results[0].DataRow[0];
        }