public Postcard withSparseParcelableArray(@Nullable String key, @Nullable SparseArray<? extends Parcelable> value) {
        mBundle.putSparseParcelableArray(key, value);
        return this;
    }