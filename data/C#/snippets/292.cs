public override Task ConnectToPeerAsync(ProtocolNetworkAddress peerAddress, CancellationToken token)
        {
            IPAddress address = peerAddress.Address;
            ushort port = peerAddress.Port;

            IPEndPoint endPoint = new IPEndPoint(address, port);
            return this.rawNetwork.ConnectToClientAsync(endPoint, token);
        }