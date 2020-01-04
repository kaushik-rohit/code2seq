public static String getGrouperGroupAttribute(final GrouperGroupField groupField, final WsGroup group) {
        switch (groupField) {
            case DISPLAY_EXTENSION:
                return group.getDisplayExtension();
            case DISPLAY_NAME:
                return group.getDisplayName();
            case EXTENSION:
                return group.getExtension();
            case NAME:
            default:
                return group.getName();
        }
    }