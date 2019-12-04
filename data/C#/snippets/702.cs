public IResourceResult Execute(IResourceContext context, IGlimpseConfiguration configuration)
        {
            //TODO: Can't assume this is here 
            var request = context.PersistenceStore.GetTop(1).FirstOrDefault(); 
            if (request == null)
                return new HtmlResourceResult("<html><body><h1>Sorry no requests are currently available</h1>This is a current limitation of this feature. For Glimpse client to work, Glimpse has to detect at least one requesting for which it is enabled.<br /><br />If you are using this feature and it is causing you issues, please let us know.</body></html>");

            var popupResource = configuration.Resources.FirstOrDefault(r => r.Name.Equals("glimpse_popup", StringComparison.InvariantCultureIgnoreCase));
            var popupUriTemplate = configuration.ResourceEndpoint.GenerateUriTemplate(popupResource, configuration.EndpointBaseUri, configuration.Logger);

            return new CacheControlDecorator(0, CacheSetting.NoCache, new RedirectResourceResult(popupUriTemplate, new Dictionary<string, object> { { ResourceParameter.RequestId.Name, request.RequestId.ToString() } }));
        }