public override async Task AcknowledgePeerVersionAsync(INetworkPeer peer, CancellationToken token)
        {
            VerAckMessageBuilder builder = new VerAckMessageBuilder(this.rawNetwork, this.hashAlgorithmStore);
            INetworkMessage response = builder.BuildVerAckMessage(peer);
            await this.rawNetwork.SendMessageToClientAsync(peer, response, token).ConfigureAwait(false);
        }