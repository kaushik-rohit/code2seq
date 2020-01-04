public override async Task RequestBlockOffersAsync(INetworkPeer peer, IEnumerable<FancyByteArray> knownBlockIdentifiers, BlockRequestType requestType, CancellationToken token)
        {
            switch (requestType)
            {
                case BlockRequestType.HeadersOnly:
                case BlockRequestType.IncludeTransactions:
                    break;

                default:
                    throw new ArgumentOutOfRangeException("requestType", requestType, "Unrecognized value.");
            }

            IReadOnlyList<FancyByteArray> blockIdentifierCollection = knownBlockIdentifiers as IReadOnlyList<FancyByteArray> ?? knownBlockIdentifiers.GetArray();
            List<FancyByteArray> listToRequest = new List<FancyByteArray>();

            int step = 1;
            int start = 0;
            for (int i = blockIdentifierCollection.Count - 1; i > 0; start++, i -= step)
            {
                if (start >= 10)
                {
                    step *= 2;
                }

                listToRequest.Add(blockIdentifierCollection[i]);
            }

            listToRequest.Add(blockIdentifierCollection[0]);

            GetBlocksMessageBuilder b = new GetBlocksMessageBuilder(this.rawNetwork, this.hashAlgorithmStore);
            var message = b.BuildGetBlocksMessage(peer, listToRequest, new FancyByteArray(), requestType);
            await this.rawNetwork.SendMessageToClientAsync(peer, message, token).ConfigureAwait(false);
        }