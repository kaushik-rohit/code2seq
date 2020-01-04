public String get(CharSequence name, String defaultValue) {
        String value = get(name);
        if (value == null) {
            return defaultValue;
        }
        return value;
    }