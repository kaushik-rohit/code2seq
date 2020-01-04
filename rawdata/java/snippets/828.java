public static boolean isFormData(HttpRequest<?> request) {
        Optional<MediaType> opt = request.getContentType();
        if (opt.isPresent()) {
            MediaType contentType = opt.get();
            return (contentType.equals(MediaType.APPLICATION_FORM_URLENCODED_TYPE) || contentType.equals(MediaType.MULTIPART_FORM_DATA_TYPE));
        }
        return false;
    }