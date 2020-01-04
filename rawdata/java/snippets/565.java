protected String addEndSlash(@NonNull String target) {
        if (!target.endsWith(File.separator)) target = target + File.separator;
        return target;
    }