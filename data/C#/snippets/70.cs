public static IList<OrderNote> GetNotesForOrder(Order order, IList<string> categories, bool includeVirtual)
		{
			var virtualNotes = new List<OrderNote>();
			if(includeVirtual)
			{
				foreach (IOrderNoteProvider virtualNoteProvider in new VirtualOrderNoteProviderExtensionPoint().CreateExtensions())
				{
					virtualNotes.AddRange(virtualNoteProvider.GetNotes(order, categories, PersistenceScope.CurrentContext));
				}
			}
			
			var where = new OrderNoteSearchCriteria();
			where.Order.EqualTo(order);
			where.PostTime.IsNotNull(); // only posted notes
			if (categories != null && categories.Count > 0)
			{
				where.Category.In(categories);
			}

			//run a query to find order notes
			//TODO: using PersistenceScope is maybe not ideal but no other option right now (fix #3472)
			var persistentNotes = PersistenceScope.CurrentContext.GetBroker<IOrderNoteBroker>().Find(where);

			return CollectionUtils.Concat(persistentNotes, virtualNotes);
		}