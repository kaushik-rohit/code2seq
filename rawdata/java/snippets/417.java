public String[] getStrings(String name) {
        String valueString = get(name);
        return StringUtils.split(valueString, ",");
    }