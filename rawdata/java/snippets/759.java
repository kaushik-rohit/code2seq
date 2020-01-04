@Override
  public TsiPeer extractPeer() throws GeneralSecurityException {
    Preconditions.checkState(!isInProgress(), "Handshake is not complete.");
    List<TsiPeer.Property<?>> peerProperties = new ArrayList<>();
    peerProperties.add(
        new TsiPeer.StringProperty(
            TSI_SERVICE_ACCOUNT_PEER_PROPERTY,
            handshaker.getResult().getPeerIdentity().getServiceAccount()));
    return new TsiPeer(peerProperties);
  }