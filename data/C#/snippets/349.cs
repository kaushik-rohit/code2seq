public static IObservable<Either<DownloadProgressChangedEventArgs, Stream>> OpenReadWithProgress(
      this WebClient client,
      Uri address)
    {
      Contract.Requires(client != null);
      Contract.Requires(address != null);
      Contract.Ensures(Contract.Result<IObservable<Either<DownloadProgressChangedEventArgs, Stream>>>() != null);

      return Observable2.FromEventBasedAsyncPattern<OpenReadCompletedEventHandler, OpenReadCompletedEventArgs, DownloadProgressChangedEventHandler, DownloadProgressChangedEventArgs>(
        handler => handler.Invoke,
        handler => client.OpenReadCompleted += handler,
        handler => client.OpenReadCompleted -= handler,
        handler => handler.Invoke,
        handler => client.DownloadProgressChanged += handler,
        handler => client.DownloadProgressChanged -= handler,
        token => client.OpenReadAsync(address, token),
        client.CancelAsync)
        .Select(
          left => left.EventArgs,
          right => right.EventArgs.Result);
    }