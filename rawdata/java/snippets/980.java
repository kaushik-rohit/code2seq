public int addOrUpdate(Entity entity) throws SQLException {
		return null == entity.get(primaryKeyField) ? add(entity) : update(entity);
	}