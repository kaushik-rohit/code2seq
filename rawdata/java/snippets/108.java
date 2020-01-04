@SuppressWarnings("SynchronizationOnLocalVariableOrMethodParameter")
    public List<Connection> getConnections(final ConnectionMode connectionMode, final String dataSourceName, final int connectionSize, final TransactionType transactionType) throws SQLException {
        DataSource dataSource = dataSources.get(dataSourceName);
        if (1 == connectionSize) {
            return Collections.singletonList(createConnection(transactionType, dataSourceName, dataSource));
        }
        if (ConnectionMode.CONNECTION_STRICTLY == connectionMode) {
            return createConnections(transactionType, dataSourceName, dataSource, connectionSize);
        }
        synchronized (dataSource) {
            return createConnections(transactionType, dataSourceName, dataSource, connectionSize);
        }
    }