public virtual OrderNote CreateGhostCopy()
		{
			return new OrderNote(
				this.Category,
				this.Body,
				this.Urgent,
				this.CreationTime,
				this.Author,
				this.OnBehalfOfGroup,
				this.PostTime,
				this.IsFullyAcknowledged,
				false,							// ghost copies do not have postings
				new HashedSet<NotePosting>(),	// ghost copies do not have postings
				this,
				_order);
		}