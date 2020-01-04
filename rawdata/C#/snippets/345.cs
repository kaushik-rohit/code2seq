public static IObservable<Stream> OpenReadObservable(
      this WebClient client,
      Uri address)
    {
      Contract.Requires(client != null);
      Contract.Requires(address != null);
      Contract.Ensures(Contract.Result<IObservable<Stream>>() != null);

      return Observable2.FromEventBasedAsyncPattern<OpenReadCompletedEventHandler, OpenReadCompletedEventArgs>(
        handler => handler.Invoke,
        handler => client.OpenReadCompleted += handler,
        handler => client.OpenReadCompleted -= handler,
        token => client.OpenReadAsync(address, token),
        client.CancelAsync)
        .Select(e => e.EventArgs.Result);
    }