@Override
  protected AutoBuffer writeAll_impl(AutoBuffer ab) {
    for (Key<Model> k : _models.values())
      ab.putKey(k);
    return super.writeAll_impl(ab);
  }