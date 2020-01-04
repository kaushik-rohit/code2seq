public override async Task SendPingAsync(INetworkPeer peer, ulong nonce, CancellationToken token)
        {
            PingMessageBuilder messageBuilder = new PingMessageBuilder(this.rawNetwork, this.hashAlgorithmStore);
            INetworkMessage message = messageBuilder.BuildPingMessage(peer, nonce);
            await this.rawNetwork.SendMessageToClientAsync(peer, message, token).ConfigureAwait(false);
        }