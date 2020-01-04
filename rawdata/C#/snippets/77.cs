[Bam.Net.Exclude]
		public static async Task BatchQuery<ColType>(int batchSize, WhereDelegate<NotificationSubscriptionColumns> where, Action<IEnumerable<NotificationSubscription>> batchProcessor, Bam.Net.Data.OrderBy<NotificationSubscriptionColumns> orderBy, Database database = null)
		{
			await System.Threading.Tasks.Task.Run(async ()=>
			{
				NotificationSubscriptionColumns columns = new NotificationSubscriptionColumns();
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await System.Threading.Tasks.Task.Run(()=>
					{ 
						batchProcessor(results);
					});
					ColType top = results.Select(d => d.Property<ColType>(orderBy.Column.ToString())).ToArray().Largest();
					results = Top(batchSize, (NotificationSubscriptionColumns)where(columns) && orderBy.Column > top, orderBy, database);
				}
			});			
		}