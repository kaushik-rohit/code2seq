public override async Task AnnounceVersionToPeerAsync(INetworkPeer peer, int version, ulong services, Instant timestamp, ulong nonce, string userAgent, int startHeight, bool pleaseRelayTransactionsToMe, CancellationToken token)
        {
            ProtocolNetworkAddress sendingAddress = new ProtocolNetworkAddress(null, 1, peer.LocalEndPoint.Address, (ushort)peer.LocalEndPoint.Port);
            ProtocolNetworkAddress receivingAddress = new ProtocolNetworkAddress(null, 1, peer.RemoteEndPoint.Address, (ushort)peer.RemoteEndPoint.Port);
            ProtocolVersionPacket packet = new ProtocolVersionPacket(version, services, timestamp, receivingAddress, sendingAddress, nonce, userAgent, startHeight, pleaseRelayTransactionsToMe);

            VersionMessageBuilder messageBuilder = new VersionMessageBuilder(this.rawNetwork, this.hashAlgorithmStore);
            INetworkMessage message = messageBuilder.BuildVersionMessage(peer, packet);
            await this.rawNetwork.SendMessageToClientAsync(peer, message, token).ConfigureAwait(false);
        }