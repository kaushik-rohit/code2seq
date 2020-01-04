public static Gson createH2oCompatibleGson() {
    return new GsonBuilder()
            // .registerTypeAdapterFactory(new ModelV3TypeAdapter())
            .registerTypeAdapter(KeyV3.class, new KeySerializer())
            .registerTypeAdapter(FrameV3.ColSpecifierV3.class, new ColSerializer())
            // .registerTypeAdapter(ModelBuilderSchema.class, new ModelDeserializer())
            // .registerTypeAdapter(ModelSchemaBaseV3.class, new ModelSchemaDeserializer())
            .create();
  }