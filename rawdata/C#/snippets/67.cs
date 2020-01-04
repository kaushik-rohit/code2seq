public static void DisposeTemporalSession(this IClientSubscription adapter, ref IaonSession session)
        {
            if ((object)session != null)
            {
                EventHandler<EventArgs<string, UpdateType>> statusMessageFunction;
                EventHandler<EventArgs<Exception>> processExceptionFunction;
                EventHandler processingCompletedFunction;

                // Remove and detach from event handlers
                if (s_statusMessageHandlers.TryRemove(adapter, out statusMessageFunction))
                    session.StatusMessage -= statusMessageFunction;

                if (s_processExceptionHandlers.TryRemove(adapter, out processExceptionFunction))
                    session.ProcessException -= processExceptionFunction;

                if (s_processingCompletedHandlers.TryRemove(adapter, out processingCompletedFunction))
                    session.ProcessingComplete -= processingCompletedFunction;

                session.Dispose();
            }

            session = null;
        }