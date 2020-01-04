protected final @Nonnull Result<T> monitorDetailed() throws InterruptedException {
        Map<Computer,Future<T>> futures = new HashMap<>();
        Set<Computer> skipped = new HashSet<>();

        for (Computer c : Jenkins.getInstance().getComputers()) {
            try {
                VirtualChannel ch = c.getChannel();
                futures.put(c,null);    // sentinel value
                if (ch!=null) {
                    Callable<T, ?> cc = createCallable(c);
                    if (cc!=null)
                        futures.put(c,ch.callAsync(cc));
                }
            } catch (RuntimeException | IOException e) {
                LOGGER.log(WARNING, "Failed to monitor "+c.getDisplayName()+" for "+getDisplayName(), e);
            }
        }

        final long now = System.currentTimeMillis();
        final long end = now + getMonitoringTimeOut();

        final Map<Computer,T> data = new HashMap<>();

        for (Entry<Computer, Future<T>> e : futures.entrySet()) {
            Computer c = e.getKey();
            Future<T> f = futures.get(c);
            data.put(c, null);  // sentinel value

            if (f!=null) {
                try {
                    data.put(c,f.get(Math.max(0,end-System.currentTimeMillis()), MILLISECONDS));
                } catch (RuntimeException | TimeoutException | ExecutionException x) {
                    LOGGER.log(WARNING, "Failed to monitor " + c.getDisplayName() + " for " + getDisplayName(), x);
                }
            } else {
                skipped.add(c);
            }
        }

        return new Result<>(data, skipped);
    }