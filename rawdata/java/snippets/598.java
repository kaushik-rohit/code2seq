public boolean containsColumn(final String tableName, final String column) {
        return containsTable(tableName) && tables.get(tableName).getColumns().keySet().contains(column.toLowerCase());
    }