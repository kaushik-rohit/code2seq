public void RecordValue()
        {
            double newValue = Value;

            lock (m_samples)
            {
                if (m_samples.Count >= m_maxSamples)
                    m_samples.Dequeue();

//                m_log.DebugFormat("[STAT]: Recording value {0} for {1}", newValue, Name);

                m_samples.Enqueue(newValue);
            }
        }