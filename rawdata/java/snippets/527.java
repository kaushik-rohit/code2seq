private ConvertibleValues<Object> newConvertibleValues(Map<CharSequence, Object> values) {
        if (CollectionUtils.isEmpty(values)) {
            return ConvertibleValues.EMPTY;
        } else {
            return ConvertibleValues.of(values);
        }
    }