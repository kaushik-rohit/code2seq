public override AdsClient CreateService(ServiceSignature signature, AdsUser user,
            Uri serverUrl)
        {
            AdManagerAppConfig adManagerConfig = (AdManagerAppConfig) Config;
            if (serverUrl == null)
            {
                serverUrl = new Uri(adManagerConfig.AdManagerApiServer);
            }

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            CheckServicePreconditions(signature);

            AdManagerServiceSignature adManagerSignature = signature as AdManagerServiceSignature;
            EndpointAddress endpoint = new EndpointAddress(string.Format(ENDPOINT_TEMPLATE,
                serverUrl, adManagerSignature.Version, adManagerSignature.ServiceName));

            // Create the binding for the service
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.TextEncoding = Encoding.UTF8;

            AdsClient service = (AdsClient) Activator.CreateInstance(adManagerSignature.ServiceType,
                new object[]
                {
                    binding,
                    endpoint
                });

            ServiceEndpoint serviceEndpoint =
                (ServiceEndpoint) service.GetType().GetProperty("Endpoint").GetValue(service, null);

            AdsServiceInspectorBehavior inspectorBehavior = new AdsServiceInspectorBehavior();
            inspectorBehavior.Add(new OAuthClientMessageInspector(user.OAuthProvider));

            RequestHeader clonedHeader = (RequestHeader) requestHeader.Clone();
            clonedHeader.Version = adManagerSignature.Version;
            inspectorBehavior.Add(new AdManagerSoapHeaderInspector()
            {
                RequestHeader = clonedHeader,
                Config = adManagerConfig
            });
            inspectorBehavior.Add(new SoapListenerInspector(user, adManagerSignature.ServiceName));
            inspectorBehavior.Add(new SoapFaultInspector<AdManagerApiException>()
            {
                ErrorType =
                    adManagerSignature.ServiceType.Assembly.GetType(
                        adManagerSignature.ServiceType.Namespace + ".ApiException"),
            });
#if NET452
      serviceEndpoint.Behaviors.Add(inspectorBehavior);
#else
            serviceEndpoint.EndpointBehaviors.Add(inspectorBehavior);
#endif

            if (adManagerConfig.Proxy != null)
            {
                service.Proxy = adManagerConfig.Proxy;
            }

            service.EnableDecompression = adManagerConfig.EnableGzipCompression;
            service.Timeout = adManagerConfig.Timeout;
            service.UserAgent = adManagerConfig.GetUserAgent();

            service.Signature = signature;
            service.User = user;
            return service;
        }