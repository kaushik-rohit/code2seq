public static String preprocess(String text)
    {
        return text.replaceAll("\\p{P}", " ").replaceAll("\\s+", " ").toLowerCase(Locale.getDefault());
    }