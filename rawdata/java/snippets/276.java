public synchronized void close(final boolean forceClose) throws SQLException {
        Collection<SQLException> exceptions = new LinkedList<>();
        MasterVisitedManager.clear();
        exceptions.addAll(closeResultSets());
        exceptions.addAll(closeStatements());
        if (!stateHandler.isInTransaction() || forceClose) {
            exceptions.addAll(releaseConnections(forceClose));
        }
        stateHandler.doNotifyIfNecessary();
        throwSQLExceptionIfNecessary(exceptions);
    }