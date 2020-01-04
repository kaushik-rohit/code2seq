@Deprecated
    public Blade get(@NonNull String path, @NonNull RouteHandler0 handler) {
        this.routeMatcher.addRoute(path, handler, HttpMethod.GET);
        return this;
    }