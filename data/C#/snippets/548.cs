public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            try
            {
                if (activity.Type == ActivityTypes.Message)
                {
                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    //// calculate something for us to return
                    //int length = (activity.Text ?? string.Empty).Length;
                    //// return our reply to the user
                    //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                    //await connector.Conversations.ReplyToActivityAsync(reply);

                    await Conversation.SendAsync(activity, () => new WivaldyDialog());
                }
                else
                {
                    await HandleSystemMessage(activity);
                }
                

            }
            catch (Exception ex)
            {
                var reply = activity.CreateReply($"error. {ex.Message}");

                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                await connector.Conversations.ReplyToActivityAsync(reply);

            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }