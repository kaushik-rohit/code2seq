protected override void AttemptConnection()
        {
            string connectionString = string.Format("server={0}:{1}", m_server, m_port);

            if (m_mongo != null)
                m_mongo.Dispose();

            // Connect to the MongoDB daemon.
            m_mongo = new Mongo(connectionString);
            m_mongo.Connect();

            // Retrieve the database, collection, and measurement timestamps.
            m_measurementDatabase = m_mongo.GetDatabase(m_databaseName);
            m_measurementCollection = m_measurementDatabase.GetCollection<MeasurementWrapper>(m_collectionName);

            if (m_timer != null)
                m_timer.Dispose();

            // Begin the timer to publish the measurements.
            m_timer = new Timer(1000.0D / m_framesPerSecond);
            m_timer.Elapsed += Timer_Elapsed;
            m_timer.AutoReset = true;
            m_timer.Start();
        }