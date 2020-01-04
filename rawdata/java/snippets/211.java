public <T> T act(final FileCallable<T> callable) throws IOException, InterruptedException {
        return act(callable,callable.getClass().getClassLoader());
    }