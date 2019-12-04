protected override dynamic BuildPagingQueryPair(string sql = "", string primaryKeyField = "", string whereClause = "", string orderByClause = "", string columns = "*", int pageSize = 20, int currentPage = 1)
        {
            var orderByClauseFragment = string.IsNullOrEmpty(orderByClause)
                ? $" ORDER BY {(string.IsNullOrEmpty(primaryKeyField) ? PrimaryKeyField : primaryKeyField)}"
                : ReadifyOrderByClause(orderByClause);

            var coreQuery = string.Format(GetSelectQueryPattern(0, ReadifyWhereClause(whereClause), orderByClauseFragment), columns, string.IsNullOrEmpty(sql) ? TableName : sql);

            var pageStart = (currentPage - 1) * pageSize;
            dynamic toReturn = new ExpandoObject();
            toReturn.CountQuery = $"SELECT COUNT(*) FROM ({coreQuery}) q";
            toReturn.MainQuery = $"{coreQuery} LIMIT {pageSize} OFFSET {pageStart + pageSize}";

            return toReturn;
        }