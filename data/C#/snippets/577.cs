protected void Application_Start()
		{
			// Create the tenant ID strategy. Required for multitenant integration.
			var tenantIdStrategy = new RequestParameterTenantIdentificationStrategy("tenant");

			// Register application-level dependencies and controllers. Note that
			// we are manually registering controllers rather than all at the same
			// time because some of the controllers in this sample application
			// are for specific tenants.
			var builder = new ContainerBuilder();
			builder.RegisterType<HomeController>();
			builder.RegisterType<BaseDependency>().As<IDependency>();

			// Adding the tenant ID strategy into the container so controllers
			// can display output about the current tenant.
			builder.RegisterInstance(tenantIdStrategy).As<ITenantIdentificationStrategy>();

			// The service client is not different per tenant because
			// the service itself is multitenant - one client for all
			// the tenants and the service implementation switches.
			builder.Register(c => new ChannelFactory<IMultitenantService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:63578/MultitenantService.svc"))).SingleInstance();
			builder.Register(c => new ChannelFactory<IMetadataConsumer>(new WSHttpBinding(), new EndpointAddress("http://localhost:63578/MetadataConsumer.svc"))).SingleInstance();

			// Register an endpoint behavior on the client channel factory that
			// will propagate the tenant ID across the wire in a message header.
			// On the service side, you'll need to read the header from incoming
			// message headers to reconstitute the incoming tenant ID.
			builder.Register(c =>
			{
				var factory = c.Resolve<ChannelFactory<IMultitenantService>>();
				factory.Opening += (sender, args) => factory.Endpoint.Behaviors.Add(new TenantPropagationBehavior<string>(tenantIdStrategy));
				return factory.CreateChannel();
			}).InstancePerHttpRequest();
			builder.Register(c =>
			{
				var factory = c.Resolve<ChannelFactory<IMetadataConsumer>>();
				factory.Opening += (sender, args) => factory.Endpoint.Behaviors.Add(new TenantPropagationBehavior<string>(tenantIdStrategy));
				return factory.CreateChannel();
			}).InstancePerHttpRequest();

			// Create the multitenant container based on the application
			// defaults - here's where the multitenant bits truly come into play.
			var mtc = new MultitenantContainer(tenantIdStrategy, builder.Build());

			// Notice we configure tenant IDs as strings below because the tenant
			// identification strategy retrieves string values from the request
			// context. To use strongly-typed tenant IDs, create a custom tenant
			// identification strategy that returns the appropriate type.

			// Configure overrides for tenant 1 - dependencies, controllers, etc.
			mtc.ConfigureTenant("1",
				b =>
				{
					b.RegisterType<Tenant1Dependency>().As<IDependency>().InstancePerDependency();
					b.RegisterType<Tenant1Controller>().As<HomeController>();
				});

			// Configure overrides for tenant 2 - dependencies, controllers, etc.
			mtc.ConfigureTenant("2",
				b =>
				{
					b.RegisterType<Tenant2Dependency>().As<IDependency>().SingleInstance();
					b.RegisterType<Tenant2Controller>().As<HomeController>();
				});

			// Configure overrides for the default tenant. That means the default
			// tenant will have some different dependencies than other unconfigured
			// tenants.
			mtc.ConfigureTenant(null, b => b.RegisterType<DefaultTenantDependency>().As<IDependency>().SingleInstance());

			// Create the dependency resolver using the
			// multitenant container instead of the application container.
			DependencyResolver.SetResolver(new AutofacDependencyResolver(mtc));

			// Perform the standard MVC setup requirements.
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
		}