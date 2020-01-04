public static JsonElement parseReader(JsonReader reader)
      throws JsonIOException, JsonSyntaxException {
    boolean lenient = reader.isLenient();
    reader.setLenient(true);
    try {
      return Streams.parse(reader);
    } catch (StackOverflowError e) {
      throw new JsonParseException("Failed parsing JSON source: " + reader + " to Json", e);
    } catch (OutOfMemoryError e) {
      throw new JsonParseException("Failed parsing JSON source: " + reader + " to Json", e);
    } finally {
      reader.setLenient(lenient);
    }
  }