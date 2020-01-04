public static Validation<String> moreThan(int size) {
        return notEmpty().and(moreThan(size, I18N_MAP.get(i18nPrefix + "MORE_THAN")));
    }