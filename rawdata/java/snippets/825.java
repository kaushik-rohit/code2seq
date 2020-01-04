public static String logicDeleteColumnEqualsValue(EntityColumn column, boolean isDeleted) {
        String result = "";
        if (column.getEntityField().isAnnotationPresent(LogicDelete.class)) {
            result = column.getColumn() + " = " + getLogicDeletedValue(column, isDeleted);
        }
        return result;
    }