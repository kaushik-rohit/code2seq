@SneakyThrows
    public static void render(final HttpServletResponse response) {
        val map = new HashMap<String, Object>();
        response.setStatus(HttpServletResponse.SC_OK);
        render(map, response);
    }