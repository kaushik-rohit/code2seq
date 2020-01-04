@Inject
    public void setCodecConfiguration(@Nullable Configuration.CodecConfiguration codecConfiguration) {
        if (codecConfiguration != null) {
            configuration.withCodec(codecConfiguration);
        }
    }