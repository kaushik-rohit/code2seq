public static OrderNote CreateVirtualNote(Order order, string category, Staff author, string body, DateTime postTime)
		{
			return new OrderNote(
				category,
				body,
				false,
				postTime,
				author,
				null,
				postTime,
				false,
				false,
				new HashedSet<NotePosting>(),
				null,
				order);
		}