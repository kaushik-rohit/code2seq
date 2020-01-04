private static Dialect internalNewDialect(String driverName) {
		if (StrUtil.isNotBlank(driverName)) {
			if (DRIVER_MYSQL.equalsIgnoreCase(driverName) || DRIVER_MYSQL_V6.equalsIgnoreCase(driverName)) {
				return new MysqlDialect();
			} else if (DRIVER_ORACLE.equalsIgnoreCase(driverName) || DRIVER_ORACLE_OLD.equalsIgnoreCase(driverName)) {
				return new OracleDialect();
			} else if (DRIVER_SQLLITE3.equalsIgnoreCase(driverName)) {
				return new Sqlite3Dialect();
			} else if (DRIVER_POSTGRESQL.equalsIgnoreCase(driverName)) {
				return new PostgresqlDialect();
			} else if (DRIVER_H2.equalsIgnoreCase(driverName)) {
				return new H2Dialect();
			} else if (DRIVER_SQLSERVER.equalsIgnoreCase(driverName)) {
				return new SqlServer2012Dialect();
			}
		}
		// 无法识别可支持的数据库类型默认使用ANSI方言，可兼容大部分SQL语句
		return new AnsiSqlDialect();
	}