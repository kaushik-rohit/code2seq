public static String joinURL(String base, String[] paths) {
        StringBuilder result = new StringBuilder(base);
        Arrays.stream(paths).map(path -> path.replaceFirst("^(\\/)+", "")).forEach(p -> {
            if (result.lastIndexOf("/") != result.length() - 1) {
                result.append('/');
            }
            result.append(p);
        });
        return result.toString();
    }