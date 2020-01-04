public static void Initialise(bool initialiseFormsPushUI = true)
		{
			lock (Lock)
			{
				if (_isInitialised)
				{
					throw new InvalidOperationException("DonkyPushUIiOS is already initialised");
				}

				if (initialiseFormsPushUI)
				{
					DonkyPushUIXamarinForms.Initialise();
				}

				DonkyCore.Instance.RegisterModule(Module);
				DonkyCore.Instance.SubscribeToLocalEvent<SimplePushMessageReceivedEvent>(HandleSimplePushReceived);
				DonkyCore.Instance.SubscribeToLocalEvent<MessageReceivedEvent>(HandleMessageReceived);
				DonkyCore.Instance.SubscribeToLocalEvent<ConfigurationUpdatedEvent>(HandleConfigurationUpdated);
				DonkyCore.Instance.SubscribeToLocalEvent<ApnsNotificationActionEvent>(HandleNotificationAction);

				_categoryProvider = new ApnsCategoryProvider(DonkyCore.Instance.GetService<IPersistentStorage>());
				DonkyCore.Instance.GetService<IApnsConfigurationProvider>().RegisterCategoryProvider(_categoryProvider);
	
				_isInitialised = true;
			}
		}