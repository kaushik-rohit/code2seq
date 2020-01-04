private Entity fixEntity(Entity entity){
		if(null == entity){
			entity = Entity.create(tableName);
		}else if(StrUtil.isBlank(entity.getTableName())){
			entity.setTableName(tableName);
		}
		return entity;
	}