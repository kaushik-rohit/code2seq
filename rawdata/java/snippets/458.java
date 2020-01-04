public String decryptValue(final String value) {
        try {
            return decryptValuePropagateExceptions(value);
        } catch (final Exception e) {
            LOGGER.error("Could not decrypt value [{}]", value, e);
        }
        return null;
    }