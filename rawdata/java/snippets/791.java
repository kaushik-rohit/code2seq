@Override
    public Schema transform(Schema schema) {
        int nCols = schema.numColumns();
        List<ColumnMetaData> meta = schema.getColumnMetaData();
        List<ColumnMetaData> newMeta = new ArrayList<>(nCols);
        newMeta.addAll(meta);
        newMeta.add(new StringMetaData(outputColumnName));
        return schema.newSchema(newMeta);
    }