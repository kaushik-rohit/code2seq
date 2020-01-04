public String convertToPageSql(String sql, Integer offset, Integer limit) {
        //解析SQL
        Statement stmt;
        try {
            stmt = CCJSqlParserUtil.parse(sql);
        } catch (Throwable e) {
            throw new PageException("不支持该SQL转换为分页查询!", e);
        }
        if (!(stmt instanceof Select)) {
            throw new PageException("分页语句必须是Select查询!");
        }
        //获取分页查询的select
        Select pageSelect = getPageSelect((Select) stmt);
        String pageSql = pageSelect.toString();
        //缓存移到外面了，所以不替换参数
        if (offset != null) {
            pageSql = pageSql.replace(START_ROW, String.valueOf(offset));
        }
        if (limit != null) {
            pageSql = pageSql.replace(PAGE_SIZE, String.valueOf(limit));
        }
        return pageSql;
    }