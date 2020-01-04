@Override
  protected Futures remove_impl(final Futures fs) {
    for (Key<Model> k : _models.values())
      k.remove(fs);
    _models.clear();
    return fs;
  }