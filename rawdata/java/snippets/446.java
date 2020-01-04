private static void appendCondition(DbMapping dbMapping, StringBuilder sql, Map<String, Object> values,
                                        ResultSet rs) throws SQLException {
        // 拼接主键
        for (Map.Entry<String, String> entry : dbMapping.getTargetPk().entrySet()) {
            String targetColumnName = entry.getKey();
            String srcColumnName = entry.getValue();
            if (srcColumnName == null) {
                srcColumnName = targetColumnName;
            }
            sql.append(targetColumnName).append("=? AND ");
            values.put(targetColumnName, rs.getObject(srcColumnName));
        }
        int len = sql.length();
        sql.delete(len - 4, len);
    }