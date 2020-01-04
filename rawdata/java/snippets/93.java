public PageResult<Entity> page(Entity where, Page page) throws SQLException {
		return this.page(where.getFieldNames(), where, page);
	}