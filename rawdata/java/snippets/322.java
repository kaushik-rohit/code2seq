public Environment addAll(@NonNull Map<String, String> map) {
        map.forEach((key, value) -> this.props.setProperty(key, value));
        return this;
    }