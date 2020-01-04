public bool StopServerControlled(bool AForceAutomaticClosing)
        {
            const int SLEEP_TIME_PER_RETRY = 500; // 500 milliseconds = 0.5 seconds
            const int MAX_RETRIES = 100; // = 500 milliseconds * 100 = 50 seconds
            int Retries = 0;

            Console.WriteLine();
            TLogging.Log(Catalog.GetString("CONTROLLED SHUTDOWN PROCEDURE INITIATED"));

            // Check if there are still Clients connected
            if (ClientsConnected > 0)
            {
                // At least one Client is still connected
                TLogging.Log("  " +
                    String.Format(Catalog.GetString("CONTROLLED SHUTDOWN: Notifying all connected Clients ({0} {1}). Please wait..."),
                        ClientsConnected, ClientsConnected > 1 ? "Clients" : "Client"));

                // Queue a ClientTask for all connected Clients that asks them to save the UserDefaults,  to disconnect from the Server and to close
                QueueClientTask(-1, RemotingConstants.CLIENTTASKGROUP_DISCONNECT, "IMMEDIATE", 1);

                // Loop that checks if all Clients have responded by disconnecting or if at least one Client didn't respond and a timeout was exceeded
CheckAllClientsDisconnected:
                Thread.Sleep(SLEEP_TIME_PER_RETRY);

                if ((ClientsConnected > 0)
                    && (Retries < MAX_RETRIES))
                {
                    Retries++;

                    if (Retries % 4 == 1)
                    {
                        TLogging.Log("    " +
                            String.Format(Catalog.GetString(
                                    "CONTROLLED SHUTDOWN: There {2} still {0} {1} connected. Waiting for {3} to disconnect (Waiting {4} more seconds)..."),
                                ClientsConnected, ClientsConnected > 1 ? "Clients" : "Client",
                                ClientsConnected > 1 ? "are" : "is", ClientsConnected > 1 ? "them" : "it",
                                ((SLEEP_TIME_PER_RETRY * MAX_RETRIES) - (SLEEP_TIME_PER_RETRY * Retries)) / 1000));
                    }

                    goto CheckAllClientsDisconnected;
                }

                // Check if at least one Client is still connected
                if (Retries == MAX_RETRIES)
                {
                    // Yes there is still at least one Client connected
                    TLogging.Log("  " +
                        String.Format(Catalog.GetString(
                                "CONTROLLED SHUTDOWN: {0} did not respond to the disconnect request. Enter FORCE to force closing of the {1} and shutdown the Server, or anything else to leave this command."),
                            ClientsConnected == 1 ? "One Client" : ClientsConnected + " Clients", ClientsConnected > 1 ? "Clients" : "Client"));

                    // Special handling in case this Method is called from the ServerAdminConsole application
                    if (AForceAutomaticClosing)
                    {
                        // Check again that there are still Clients connected (could have disconnected while the user was typing 'FORCE'!)
                        if (ClientsConnected > 0)
                        {
                            // Yes there is still at least one Client connected
                            TLogging.Log("    " +
                                String.Format(Catalog.GetString(
                                        "CONTROLLED SHUTDOWN: Forcing all connected Clients ({0} {1}) to close. Please wait..."),
                                    ClientsConnected, ClientsConnected > 1 ? "Clients" : "Client"));

                            // Queue a ClienTasks for all Clients that are still connected that asks them to close (no saving of UserDefaults and no disconnection from the server!). This is a fallback mechanism.
                            QueueClientTask(-1, RemotingConstants.CLIENTTASKGROUP_DISCONNECT, "IMMEDIATE-HARDEXIT", 1);

                            // Loop as long as TSrvSetting.ClientKeepAliveCheckIntervalInSeconds is to ensure that all Clients will have got the chance to pick up the queued Client Task
                            // (since it would not be easy to determine that every connected Client has picked up this message, this is the easy way of ensuring that).
                            for (int Counter = 1; Counter <= 4; Counter++)
                            {
                                TLogging.Log("    " +
                                    String.Format(Catalog.GetString(
                                            "CONTROLLED SHUTDOWN: Waiting {0} seconds so the Server can be sure that all Clients have got the message that they need to close... ({1} more seconds to wait)"),
                                        TSrvSetting.ClientKeepAliveCheckIntervalInSeconds / 1000,
                                        (TSrvSetting.ClientKeepAliveCheckIntervalInSeconds -
                                         ((TSrvSetting.ClientKeepAliveCheckIntervalInSeconds / 4) * (Counter - 1))) / 1000));

                                Thread.Sleep(TSrvSetting.ClientKeepAliveCheckIntervalInSeconds / 4);
                            }
                        }
                        else
                        {
                            // No Clients connected anymore -> we can shut down the server.
                            TLogging.Log("  " +
                                Catalog.GetString(
                                    "CONTROLLED SHUTDOWN: All Clients have disconnected in the meantine, proceeding with shutdown immediately."));
                        }
                    }
                    else
                    {
                        // Abandon the shutdown as there are still connected clients and we are not allowed to force the shutdown
                        return false;
                    }
                }
            }
            else
            {
                // No Clients connected anymore -> we can shut down the server.
                TLogging.Log("  " + Catalog.GetString("CONTROLLED SHUTDOWN: There were no Clients connected, proceeding with shutdown immediately."));
            }

            // We are now ready to stop the server.
            StopServer();

            return true;  // this will never get executed, but is necessary for that Method to compile...
        }