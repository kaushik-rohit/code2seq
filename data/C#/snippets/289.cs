public override async Task RequestInventoryAsync(IEnumerable<ProtocolInventoryVector> inventoryVectors, CancellationToken token)
        {
            INetworkPeer peer = this.ConnectedPeers.First().Value;

            INetworkMessage response = new GetDataMessageBuilder(this.rawNetwork, this.hashAlgorithmStore).BuildGetDataMessage(peer, inventoryVectors);
            await this.rawNetwork.SendMessageToClientAsync(peer, response, token).ConfigureAwait(false);
        }