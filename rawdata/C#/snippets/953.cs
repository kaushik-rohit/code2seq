private void ServerThread(object port)
        {
            try
            {
                //start server
                Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Bind(new IPEndPoint(IPAddress.Any, (int)port));
                Server.Listen(10);

                //wait for new clients
                while (IsRunning)
                {
                    var client = Server.Accept();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), client);
                }
            }
            catch (Exception ex)
            {
                DebugEx.TraceErrorException(ex);
            }

            this.Stop();
        }