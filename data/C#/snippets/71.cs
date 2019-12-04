[Bam.Net.Exclude]
		public static async Task BatchQuery(int batchSize, WhereDelegate<NotificationSubscriptionColumns> where, Action<IEnumerable<NotificationSubscription>> batchProcessor, Database database = null)
		{
			await System.Threading.Tasks.Task.Run(async ()=>
			{
				NotificationSubscriptionColumns columns = new NotificationSubscriptionColumns();
				var orderBy = Bam.Net.Data.Order.By<NotificationSubscriptionColumns>(c => c.KeyColumn, Bam.Net.Data.SortOrder.Ascending);
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await System.Threading.Tasks.Task.Run(()=>
					{ 
						batchProcessor(results);
					});
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (NotificationSubscriptionColumns)where(columns) && columns.KeyColumn > topId, orderBy, database);
				}
			});			
		}