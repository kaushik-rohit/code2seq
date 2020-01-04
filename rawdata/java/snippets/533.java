@Override
   public ResultSet executeQuery() throws SQLException
   {
      connection.markCommitStateDirty();
      ResultSet resultSet = ((PreparedStatement) delegate).executeQuery();
      return ProxyFactory.getProxyResultSet(connection, this, resultSet);
   }