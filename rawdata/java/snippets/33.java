public static void insertStopNatures(String key, String... filterNatures) {
        StopRecognition fr = get(key);
        fr.insertStopNatures(filterNatures);
    }