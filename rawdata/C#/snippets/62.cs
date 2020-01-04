public static IaonSession CreateTemporalSession(this IClientSubscription clientSubscription)
        {
            IaonSession session;

            // Cache the specified input measurement keys requested by the remote subscription
            // internally since these will only be needed in the private Iaon session
            MeasurementKey[] inputMeasurementKeys = clientSubscription.InputMeasurementKeys;
            IMeasurement[] outputMeasurements = clientSubscription.OutputMeasurements;

            // Since historical data is requested, we "turn off" interaction with the outside real-time world
            // by removing the client subscription adapter from external routes. To accomplish this we expose
            // I/O demands for an undefined measurement as assigning to null would mean "broadcast" is desired.
            clientSubscription.InputMeasurementKeys = new[] { MeasurementKey.Undefined };
            clientSubscription.OutputMeasurements = new IMeasurement[] { Measurement.Undefined };

            // Create a new Iaon session
            session = new IaonSession();
            session.Name = "<" + clientSubscription.Name.ToNonNullString("unavailable") + ">@" + clientSubscription.StartTimeConstraint.ToString("yyyy-MM-dd HH:mm:ss");

            // Assign requested input measurement keys as a routing restriction
            session.InputMeasurementKeysRestriction = inputMeasurementKeys;

            // Setup default bubbling event handlers associated with the client session adapter
            EventHandler<EventArgs<string, UpdateType>> statusMessageHandler = (sender, e) =>
            {
                if (e.Argument2 == UpdateType.Information)
                    clientSubscription.OnStatusMessage(MessageLevel.Info, e.Argument1);
                else
                    clientSubscription.OnStatusMessage(MessageLevel.Warning, "0x" + (int)e.Argument2 + e.Argument1);
            };

            EventHandler<EventArgs<Exception>> processExceptionHandler = (sender, e) => clientSubscription.OnProcessException(MessageLevel.Warning, e.Argument);
            EventHandler processingCompletedHandler = clientSubscription.OnProcessingCompleted;

            // Cache dynamic event handlers so they can be detached later
            s_statusMessageHandlers[clientSubscription] = statusMessageHandler;
            s_processExceptionHandlers[clientSubscription] = processExceptionHandler;
            s_processingCompletedHandlers[clientSubscription] = processingCompletedHandler;

            // Attach handlers to new session - this will proxy all temporal session messages through the client session adapter
            session.StatusMessage += statusMessageHandler;
            session.ProcessException += processExceptionHandler;
            session.ProcessingComplete += processingCompletedHandler;

            // Send the first message indicating a new temporal session is being established
            statusMessageHandler(null, new EventArgs<string, UpdateType>(
                // ReSharper disable once UseStringInterpolation
                string.Format("Initializing temporal session for host \"{0}\" spanning {1} to {2} processing data {3}...",
                    clientSubscription.Name.ToNonNullString("unknown"),
                    clientSubscription.StartTimeConstraint.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    clientSubscription.StopTimeConstraint.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    clientSubscription.ProcessingInterval == 0 ? "as fast as possible" :
                    clientSubscription.ProcessingInterval == -1 ? "at the default rate" : "at " + clientSubscription.ProcessingInterval + "ms intervals"),
                UpdateType.Information));

            // Duplicate current real-time session configuration for adapters that report temporal support
            session.DataSource = IaonSession.ExtractTemporalConfiguration(clientSubscription.DataSource);

            // Initialize temporal session adapters without starting them
            session.Initialize(false);

            // Define an in-situ action adapter for the temporal Iaon session used to proxy data back to the client subscription. Note
            // to enable adapters that are connect-on-demand in the temporal session, we must make sure the proxy adapter is setup to
            // respect input demands. The proxy adapter produces no points into the temporal session - all received points are simply
            // internally proxied out to the parent client subscription outside the purview of the Iaon session; from the perspective
            // of the Iaon session, points seem to dead-end in the proxy adapter. The proxy adapter is an action adapter and action
            // adapters typically produce measurements, as such, actions default to respecting output demands not input demands. Using
            // the default settings of not respecting input demands and the proxy adapter not producing any points, the Iaon session
            // would ignore the adapter's input needs. In this case we want Iaon session to recognize the inputs of the proxy adapter
            // as important to the connect-on-demand dependency chain, so we request respect for the input demands.
            TemporalClientSubscriptionProxy proxyAdapter = new TemporalClientSubscriptionProxy
            {
                // Assign critical adapter properties
                ID = 0,
                Name = "PROXY!SERVICES",
                ConnectionString = "",
                DataSource = session.DataSource,
                RespectInputDemands = true,
                InputMeasurementKeys = inputMeasurementKeys,
                OutputMeasurements = outputMeasurements,
                Parent = clientSubscription,
                Initialized = true
            };

            // Add new proxy adapter to temporal session action adapter collection - this will start adapter
            session.ActionAdapters.Add(proxyAdapter);

            // Load current temporal constraint parameters
            Dictionary<string, string> settings = clientSubscription.Settings;
            string startTime, stopTime, parameters;

            settings.TryGetValue("startTimeConstraint", out startTime);
            settings.TryGetValue("stopTimeConstraint", out stopTime);
            settings.TryGetValue("timeConstraintParameters", out parameters);

            // Assign requested temporal constraints to all private session adapters
            session.AllAdapters.SetTemporalConstraint(startTime, stopTime, parameters);
            session.AllAdapters.ProcessingInterval = clientSubscription.ProcessingInterval;

            // Start temporal session adapters
            session.AllAdapters.Start();

            // Recalculate routing tables to accommodate addition of proxy adapter and handle
            // input measurement keys restriction
            session.RecalculateRoutingTables();

            return session;
        }