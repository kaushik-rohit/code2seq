public static TableEntry versioned(@NonNull ArrayView key, @NonNull ArrayView value, long version) {
        return new TableEntry(TableKey.versioned(key, version), value);
    }