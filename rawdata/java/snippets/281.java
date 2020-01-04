@Override
    public void triggerEvent() {
        // delete all outdated events
        try {
            lock.writeLock().lock();
            long currentTime = System.currentTimeMillis();
            if (latestEvent.get() == 0)
                this.latestEvent.set(currentTime);

            actualizeCounts(currentTime);
            int currentBin = (int) TimeUnit.SECONDS.convert(currentTime, TimeUnit.MILLISECONDS) % buckets.length;

            buckets[currentBin]++;

            // nullify next bin
            if (currentBin == buckets.length - 1)
                buckets[0] = 0;
            else
                buckets[currentBin + 1] = 0;

            // set new time
            this.latestEvent.set(currentTime);
        } finally {
            lock.writeLock().unlock();
        }
    }