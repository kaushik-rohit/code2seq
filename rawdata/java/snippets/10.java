protected void internalRefreshStats()
    {
        checkState(Thread.holdsLock(root), "Must hold lock to refresh stats");
        synchronized (root) {
            if (subGroups.isEmpty()) {
                cachedMemoryUsageBytes = 0;
                for (ManagedQueryExecution query : runningQueries) {
                    cachedMemoryUsageBytes += query.getUserMemoryReservation().toBytes();
                }
            }
            else {
                for (Iterator<InternalResourceGroup> iterator = dirtySubGroups.iterator(); iterator.hasNext(); ) {
                    InternalResourceGroup subGroup = iterator.next();
                    long oldMemoryUsageBytes = subGroup.cachedMemoryUsageBytes;
                    cachedMemoryUsageBytes -= oldMemoryUsageBytes;
                    subGroup.internalRefreshStats();
                    cachedMemoryUsageBytes += subGroup.cachedMemoryUsageBytes;
                    if (!subGroup.isDirty()) {
                        iterator.remove();
                    }
                    if (oldMemoryUsageBytes != subGroup.cachedMemoryUsageBytes) {
                        subGroup.updateEligibility();
                    }
                }
            }
        }
    }