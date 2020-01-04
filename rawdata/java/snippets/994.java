private Object put(Class<?> type, boolean isSingleton) {
        return put(type.getName(), type, isSingleton);
    }