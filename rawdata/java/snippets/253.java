@SuppressWarnings("unused") // called through reflection by RequestServer
  public water.automl.api.schemas3.LeaderboardsV99 list(int version, water.automl.api.schemas3.LeaderboardsV99 s) {
    Leaderboards m = s.createAndFillImpl();
    m.leaderboards = Leaderboards.fetchAll();
    return s.fillFromImpl(m);
  }