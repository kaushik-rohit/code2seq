private static void renderException(final Map model, final HttpServletResponse response) {
        response.setStatus(HttpServletResponse.SC_BAD_REQUEST);
        model.put("status", HttpServletResponse.SC_BAD_REQUEST);
        render(model, response);
    }