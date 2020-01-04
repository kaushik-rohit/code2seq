public static JavaRDD<List<Writable>> zeromeanUnitVariance(Schema schema, JavaRDD<List<Writable>> data) {
        return zeromeanUnitVariance(schema, data, Collections.<String>emptyList());
    }