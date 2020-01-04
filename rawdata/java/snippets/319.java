public static synchronized Forest putIfAbsent(String key, String path, Forest forest) {

        KV<String, Forest> kv = DIC.get(key);
        if (kv != null && kv.getV() != null) {
            return kv.getV();
        }
        put(key, path, forest);
        return forest;
    }