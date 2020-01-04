public PageResult<Entity> page(Connection conn, Collection<String> fields, Entity where, int page, int numPerPage) throws SQLException {
		checkConn(conn);
		
		final int count = count(conn, where);
		PageResultHandler pageResultHandler = PageResultHandler.create(new PageResult<Entity>(page, numPerPage, count));
		return this.page(conn, fields, where, page, numPerPage, pageResultHandler);
	}