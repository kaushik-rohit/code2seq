public static void sortBySpecificityAndQuality(List<MediaType> mediaTypes) {
        Assert.notNull(mediaTypes, "'mediaTypes' must not be null");
        if (mediaTypes.size() > 1) {
            Collections.sort(mediaTypes, new CompoundComparator<MediaType>(MediaType.SPECIFICITY_COMPARATOR,
                MediaType.QUALITY_VALUE_COMPARATOR));
        }
    }