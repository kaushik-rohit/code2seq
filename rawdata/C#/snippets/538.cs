[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnTokenFound(TToken token)
		{
			var handler = TokenFound;
			if (handler != null)
			{
				handler(token);
			}
		}