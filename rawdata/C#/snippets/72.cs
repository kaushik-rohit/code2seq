public static OrderNote CreateGeneralNote(Order order, Staff author, string body)
		{
			return new OrderNote(
				Categories.General,
				body,
				false,
				Platform.Time,
				author,
				null,
				Platform.Time,
				false,
				false,
				new HashedSet<NotePosting>(),
				null,
				order);
		}