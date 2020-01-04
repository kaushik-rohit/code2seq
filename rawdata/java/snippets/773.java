public static void writeSchema(String outputPath, Schema schema, JavaSparkContext sc) throws IOException {
        writeStringToFile(outputPath, schema.toString(), sc);
    }