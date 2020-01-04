@Nonnull
    public final Launcher decorateFor(@Nonnull Node node) {
        Launcher l = this;
        for (LauncherDecorator d : LauncherDecorator.all())
            l = d.decorate(l,node);
        return l;
    }