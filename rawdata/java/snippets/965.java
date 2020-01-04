public @Nonnull StaticMessageSource addMessage(@Nonnull Locale locale, @Nonnull String code, @Nonnull String message) {
        ArgumentUtils.requireNonNull("locale", locale);
        if (StringUtils.isNotEmpty(code) && StringUtils.isNotEmpty(message)) {
            messageMap.put(new MessageKey(locale, code), message);
        }
        return this;
    }