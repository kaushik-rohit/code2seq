public void Start()
        {
            lock (this)
            {
                //set flag
                IsRunning = true;

                //start listener
                _ListenerThread = new Thread(new ParameterizedThreadStart(ServerThread));
                _ListenerThread.IsBackground = true;
                _ListenerThread.Start(this.Port);
            }
        }