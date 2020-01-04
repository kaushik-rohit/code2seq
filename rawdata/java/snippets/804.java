@Override
	public int deleteAllAlerts() throws DatabaseException {
    	SqlPreparedStatementWrapper psDeleteAllAlerts = null;
        try {
        	psDeleteAllAlerts = DbSQL.getSingleton().getPreparedStatement("alert.ps.deleteall");
			return psDeleteAllAlerts.getPs().executeUpdate();
		} catch (SQLException e) {
			throw new DatabaseException(e);
		} finally {
			DbSQL.getSingleton().releasePreparedStatement(psDeleteAllAlerts);
		}
    }