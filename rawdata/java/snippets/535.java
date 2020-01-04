public Postcard withInt(@Nullable String key, int value) {
        mBundle.putInt(key, value);
        return this;
    }