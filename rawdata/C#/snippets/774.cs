private void GetThread()
    {
      OAuthUtility.GetAsync
      (
        String.Format("https://api.codeproject.com/v1/MessageThread/{0}/messages", this.ThreadId),
        new HttpParameterCollection 
        { 
          { "page", this.CurrentPage }
        },
        authorization: new HttpAuthorization(AuthorizationType.Bearer, Properties.Settings.Default.AccessToken),
        callback: GetThread_Result
      );
    }