public static KV<String, SplitWord> remove(String key) {
        MyStaticValue.ENV.remove(key);
        return CRF.remove(key);
    }